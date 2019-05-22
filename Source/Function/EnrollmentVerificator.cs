using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Table;
using SendGrid.Helpers.Mail;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Tailwind.Traders.Rewards.FuncApp.Extensions;
using Tailwind.Traders.Rewards.FuncApp.Models;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Tailwind.Traders.Rewards.FuncApp
{
    public static class EnrollmentVerificator
    {
        [FunctionName("EnrollmentVerificator")]
        public static async Task RunOrchestrator(
            [OrchestrationTrigger] DurableOrchestrationContext ctx)
        {
            var data = ctx.GetInput<EnrollmentHttpRequest>();
            var notificationRequest = new RequestNotification(ctx.InstanceId, data.MobileNumber, data.Email, data.FirstName, data.LastName);
            var customerInfoRequest = new CustomerInfoRequest(data.MobileNumber, ctx.InstanceId, data.Id);

            await ctx.CallActivityAsync(Activities.StoreCustomerInformation, customerInfoRequest);

            if (data.Channel  == ChannelType.Email)
            {
                await ctx.CallActivityAsync(Activities.Email.EnrollmentRequestNotification, notificationRequest);
            }
            else
            {
                await ctx.CallActivityAsync(Activities.Sms.EnrollmentRequestNotification, notificationRequest);
            }

            using (var timeoutCts = new CancellationTokenSource())
            {
                Task<EnrollmentStatusEnum> approvalEvent = ctx.WaitForExternalEvent<EnrollmentStatusEnum>(Events.ApprovalEvent);

                DateTime reminderDueTime = ctx.CurrentUtcDateTime.AddHours(7);
                Task reminderTimeout = ctx.CreateTimer(reminderDueTime, timeoutCts.Token);

                if (approvalEvent == await Task.WhenAny(approvalEvent, reminderTimeout))
                {                   
                    var dataStatus = new UpdateStatus(data.Id, data.MobileNumber, approvalEvent.Result, data.Email);
                    
                    await ctx.CallActivityAsync(Activities.UpdateEnrollmentStatus, dataStatus);
                    if (data.Channel == ChannelType.Email)
                    {
                        await ctx.CallActivityAsync(Activities.Email.SendEnrollmentFinishedNotification, dataStatus);
                    }
                    else
                    {
                        await ctx.CallActivityAsync(Activities.Sms.SendEnrollmentFinishedNotification, dataStatus);
                    }

                    timeoutCts.Cancel();
                }
                else
                {
                    if (data.Channel == ChannelType.Email)
                    {
                        await ctx.CallActivityAsync(Activities.Sms.SendReminderEnrollmentNotification, data.MobileNumber);
                    }
                    else
                    {
                        await ctx.CallActivityAsync(Activities.Email.SendReminderEnrollmentNotification, data.Email);
                    }
                }

                await ctx.CallActivityAsync(Activities.CleanCustomerInfoTable, data.MobileNumber);
            }
        }

        [FunctionName(Activities.Sms.EnrollmentRequestNotification)]
        public static void RunSendNotification([ActivityTrigger] RequestNotification notificationRequest,
            ILogger log,
            [TwilioSms(AccountSidSetting = "TwilioAccountSid", AuthTokenSetting = "TwilioAuthToken", From = "%TwilioPhoneNumber%")] out CreateMessageOptions message)
        {
            log.LogInformation($"Sending notification to mobile number {notificationRequest.MobileNumber}.");

            var useSMSReply = Environment.GetEnvironmentVariable("UseSMSReply");
            var enrollmentAFUrl = Environment.GetEnvironmentVariable("EnrollmentAFUrl");
            var subsKey = Environment.GetEnvironmentVariable("APIM_SubsKey");
            if (Convert.ToBoolean(useSMSReply))
            {
                message = new CreateMessageOptions(new PhoneNumber(notificationRequest.MobileNumber));
                message.Body = $"Welcome to the Tailwind Traders Rewards Program! Please reply to the message with YES/ACCEPTED or NO/CANCELLED for customer enrollment";
            }
            else
            {
                message = new CreateMessageOptions(new PhoneNumber(notificationRequest.MobileNumber));
                message.Body = $"Welcome to the Tailwind Traders Rewards Program! " +
                    $"Please click one of the following links to ACCEPT or CANCEL your enrollment. " +
                    $"Click ACCEPT {enrollmentAFUrl}?action=accepted&id={notificationRequest.InstanceId}&Subscription-Key={subsKey}  Or  " +
                    $"Click CANCEL {enrollmentAFUrl}?action=rejected&id={notificationRequest.InstanceId}&Subscription-Key={subsKey}";
            }            
        }

        [FunctionName(Activities.Email.EnrollmentRequestNotification)]
        public static void RunSendNotificationEmail([ActivityTrigger] RequestNotification notificationRequest,
                    ILogger log,
                    [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message)
        {
            log.LogInformation($"Sending notification to mobile number {notificationRequest.Email}.");
            var enrollmentAFUrl = Environment.GetEnvironmentVariable("EnrollmentAFUrl");
            var subsKey = Environment.GetEnvironmentVariable("APIM_SubsKey");
            var from = Environment.GetEnvironmentVariable("SendGrid_From");
            message = new SendGridMessage();
            message.SetFrom(new EmailAddress(from));
            message.AddTo(notificationRequest.Email, notificationRequest.FullName);
            message.SetSubject("[no-reply] Welcome to Tailwind Traders Rewards Program");

            message.AddContent("text/plain", $"Welcome to the Tailwind Traders Rewards Program! " +
                $"Please click one of the following links to ACCEPT or CANCEL your enrollment. " +
                $"Click ACCEPT {enrollmentAFUrl}?action=accepted&id={notificationRequest.InstanceId}&Subscription-Key={subsKey}  Or  " +
                $"Click CANCEL {enrollmentAFUrl}?action=rejected&id={notificationRequest.InstanceId}&Subscription-Key={subsKey}");
        }

        [FunctionName(Activities.Sms.SendEnrollmentFinishedNotification)]
        public static void RunSendFinishedNotification([ActivityTrigger] UpdateStatus dataStatus,
            ILogger log,
            [TwilioSms(AccountSidSetting = "TwilioAccountSid", AuthTokenSetting = "TwilioAuthToken", From = "%TwilioPhoneNumber%")] out CreateMessageOptions message)
        {
            log.LogInformation($"Sending enrollment finished notification to mobile number {dataStatus.MobileNumber}.");

            message = new CreateMessageOptions(new PhoneNumber(dataStatus.MobileNumber));
            message.Body = dataStatus.Status == EnrollmentStatusEnum.Accepted ?
                "Thank you for your response! You have successfully been enrolled to the Tailwind Traders Rewards program" :
                "Thank you for your response! Your Tailwind Traders Rewards program enrollment has been cancelled";
        }

        [FunctionName(Activities.Email.SendEnrollmentFinishedNotification)]
        public static void RunSendFinishedNotificationEmail([ActivityTrigger] UpdateStatus dataStatus,
            ILogger log,
            [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message)
        {
            log.LogInformation($"Sending enrollment finished notification to email {dataStatus.Email}.");

            var from = Environment.GetEnvironmentVariable("SendGrid_From");
            message = new SendGridMessage();
            message.SetFrom(new EmailAddress(from));
            message.AddTo(dataStatus.Email);
            message.SetSubject("[no-reply] Tailwind Traders Rewards Program");
            var body = dataStatus.Status == EnrollmentStatusEnum.Accepted ?
                "Thank you for your response! You have successfully been enrolled to the Tailwind Traders Rewards program" :
                "Thank you for your response! Your Tailwind Traders Rewards program enrollment has been cancelled";
            message.AddContent("text/plain", body);
        }

        [FunctionName(Activities.Sms.SendReminderEnrollmentNotification)]
        public static void RunSendReminderEnrollmentNotification([ActivityTrigger] string number,
            ILogger log,
            [TwilioSms(AccountSidSetting = "TwilioAccountSid", AuthTokenSetting = "TwilioAuthToken", From = "%TwilioPhoneNumber%")] out CreateMessageOptions message)
        {
            log.LogInformation($"Sending reminder notification to mobile number {number}.");

            message = new CreateMessageOptions(new PhoneNumber(number));
            message.Body = "Reminder to accept the terms for the rewards";
        }

        [FunctionName(Activities.Email.SendReminderEnrollmentNotification)]
        public static void RunSendReminderEnrollmentNotificationEmail([ActivityTrigger] string email,
            ILogger log,
           [SendGrid(ApiKey = "SendGridApiKey")] out SendGridMessage message)
        {
            log.LogInformation($"Sending reminder notification to email {email}.");
            var from = Environment.GetEnvironmentVariable("SendGrid_From");
            message = new SendGridMessage();
            message.SetFrom(new EmailAddress(from));
            message.AddTo(email);
            message.SetSubject("[no-reply] Tailwind Traders Rewards Program");
            message.AddContent("text/plain", "Reminder to accept the terms for the rewards");
        }

        [FunctionName(Activities.EnrollmentResponseNotification)]
        public static async Task RunEnrollmentResponse(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get")]HttpRequest req,
            ILogger log,
            [OrchestrationClient] DurableOrchestrationClient client)
        {
            string isApprovedQueryString = req.Query[QueryString.Action];
            string id = req.Query[QueryString.Id];

            Enum.TryParse(isApprovedQueryString, true, out EnrollmentStatusEnum status);

            await client.RaiseEventAsync(id, Events.ApprovalEvent, status);
        }        

        [FunctionName(Activities.UpdateEnrollmentStatus)]
        public static async Task RunUpdateEnrollmentStatus(
            [ActivityTrigger] UpdateStatus dataStatus,
            ILogger log)
        {

            // Get the connection string from app settings and use it to create a connection.
            var str = Environment.GetEnvironmentVariable("sqldb_connection");
            using (SqlConnection conn = new SqlConnection(str))
            {
                conn.Open();
                var text = $"UPDATE dbo.Customers " +
                        "SET [Enrrolled] = @enrollment  WHERE CustomerId = @customerId";

                using (SqlCommand cmd = new SqlCommand(text, conn))
                {
                    cmd.Parameters.AddWithValue("@enrollment", dataStatus.Status);
                    cmd.Parameters.AddWithValue("@customerId", dataStatus.CustomerId);

                    var rows = await cmd.ExecuteNonQueryAsync();

                    if (rows > 0)
                    {
                        log.LogInformation($"User with Id: {dataStatus.CustomerId} updated to EnrollmentStatus: {dataStatus.Status}");
                    }
                    else
                    {
                        log.LogInformation($"No changes applied for User with Id: {dataStatus.CustomerId}");
                    }
                }
            }
        }

        [FunctionName(Activities.CleanCustomerInfoTable)]
        public static async Task RunCleanCustomerInfoTable(
            [Table("CustomerInformation", Connection = "AzureWebJobsStorage")]CloudTable table,
            [ActivityTrigger] string mobileNumber,
            ILogger log)
        {
            var items = await table.GetItemsAsync<CustomerInfo>(mobileNumber);
            var itemToDelete = items.FirstOrDefault();

            if (itemToDelete != null)
            {
                await table.DeleteItemAsync<CustomerInfo>(itemToDelete);
                log.LogInformation($"Cleaning customer information for user with Phone Number: {mobileNumber}.");
            }            
        }

        [FunctionName(Activities.StoreCustomerInformation)]
        [return: Table("CustomerInformation", Connection = "AzureWebJobsStorage")]
        public static CustomerInfo RunStoreCustomerInformation(
            [ActivityTrigger] CustomerInfoRequest customerInfoRequest,     
            ILogger log
        )
        {
            log.LogInformation($"Storing customer information for user with Phone Number: {customerInfoRequest.Phonenumber}.");

            var result = new CustomerInfo()
            {
                InstanceId = customerInfoRequest.InstanceId,
                Phonenumber = customerInfoRequest.Phonenumber,
                RowKey = customerInfoRequest.Phonenumber,
                PartitionKey = TableStorage.CustomerPK
            };

            return result;
        }

        [FunctionName("TwilioWebhook")]
        public static async Task<System.Net.Http.HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequest req,
            [Table("CustomerInformation", Connection = "AzureWebJobsStorage")] CloudTable table,
            [OrchestrationClient] DurableOrchestrationClient client,
            ILogger log)
        {
            string responseSMS = string.Empty;
            string dataRaw = req.Form[Form.Body];
            string fromRaw = req.Form[Form.From];

            var response = dataRaw.Trim().ToLower();
            var phoneMumber = fromRaw.Trim();

            var result = await table.GetItemsAsync<CustomerInfo>(phoneMumber);
            var customerInfofromTable = result.FirstOrDefault();

            log.LogInformation($"User with phone number: {customerInfofromTable.Phonenumber} has sent back a SMS message response with the following content: {response}");

            responseSMS = "Thank you for answering. Your request is being processed";
            if (response == TwilioSMS.Response.Accepted || response == TwilioSMS.Response.Yes)
            {
                await client.RaiseEventAsync(customerInfofromTable.InstanceId, Events.ApprovalEvent, EnrollmentStatusEnum.Accepted);
            }
            else if (response == TwilioSMS.Response.Cancelled || response == TwilioSMS.Response.No)
            {
                await client.RaiseEventAsync(customerInfofromTable.InstanceId, Events.ApprovalEvent, EnrollmentStatusEnum.Rejected);
            }
            else
            {
                responseSMS = "I could not understand you! Please, reply with YES/ACCEPTED or NO/CANCELLED";
            }            

            var twilioMsg = new Twilio.TwiML.MessagingResponse()
                .Message(responseSMS);

            var twiml = twilioMsg.ToString();
            twiml = twiml.Replace("utf-16", "utf-8");

            return new System.Net.Http.HttpResponseMessage
            {
                Content = new System.Net.Http.StringContent(twiml, System.Text.Encoding.UTF8, "application/xml")
            };
        }
    }
}