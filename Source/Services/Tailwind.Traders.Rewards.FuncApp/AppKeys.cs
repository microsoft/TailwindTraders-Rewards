using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp
{
    public static class QueryString
    {
        public const string Id = "id";
        public const string Action = "action";
    }

    public static class Form
    {
        public const string Body = "Body";
        public const string From = "From";
    }

    public static class Events
    {
        public const string ApprovalEvent = "ApprovalEvent";
    }

    public static class Activities
    {
        public const string StoreCustomerInformation = "StoreCustomerInformation";
        public const string EnrollmentRequestNotification = "EnrollmentRequestNotification"; 
        public const string UpdateEnrollmentStatus = "UpdateEnrollmentStatus";
        public const string SendEnrollmentFinishedNotification = "SendEnrollmentFinishedNotification";
        public const string SendReminderEnrollmentNotification = "SendReminderEnrollmentNotification";
        public const string EnrollmentResponseNotification = "EnrollmentResponseNotification";
        public const string CleanCustomerInfoTable = "CleanCustomerInfoTable";
    }

    public static class TableStorage
    {
        public const string CustomerPK = "customer";
    }

    public static class TwilioSMS
    {
        public static class Response
        {
            public const string Accepted = "accepted";
            public const string Yes = "yes";
            public const string Cancelled = "cancelled";
            public const string No = "no";
        }
    }
}
