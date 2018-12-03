using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Tailwind.Traders.Rewards.FuncApp.Models;
using System.Net;
using Microsoft.WindowsAzure.Storage.Table;
using System.Linq;
using Tailwind.Traders.Rewards.FuncApp.Extensions;

namespace Tailwind.Traders.Rewards.FuncApp
{
    public static class EnrollmentHttpStart
    {
        [FunctionName("EnrollmentVerificator_HttpStart")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")]HttpRequestMessage req,
            [Table("CustomerInformation", Connection = "AzureWebJobsStorage")] CloudTable table,
            [OrchestrationClient]DurableOrchestrationClient starter,
            ILogger log)
        {
            var data = await req.Content.ReadAsAsync<EnrollmentHttpRequest>();
            if(data.Enrolled != EnrollmentStatusEnum.Started)
            {
                log.LogError($"Received {data.MobileNumber} for customer ID {data.Id} ({data.FirstName} {data.LastName}) with invalid enrolled code of {data.Enrolled}");
                return new HttpResponseMessage(HttpStatusCode.BadRequest);            
            }

            var result = await table.GetItemsAsync<CustomerInfo>(data.MobileNumber);

            var customerInfofromTable = result.FirstOrDefault();

            if (customerInfofromTable != null)
            {
                log.LogInformation($"Phone number: {data.MobileNumber} is already in the enrolling process. Cancelling.");

                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }

            log.LogInformation($"Started Enrollment process for user: {data.FirstName} {data.LastName}");

            string instanceId = await starter.StartNewAsync("EnrollmentVerificator", data);

            log.LogInformation($"Starting Enrollment Orchestrator with ID: {instanceId}");
            
            return starter.CreateCheckStatusResponse(req, instanceId);
        }
    }
}
