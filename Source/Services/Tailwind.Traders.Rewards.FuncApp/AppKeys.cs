using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp
{

    public enum ChannelType
    {
        Sms = 1,
        Email = 2
    }

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
        public static class Sms
        {
            public const string EnrollmentRequestNotification = "EnrollmentRequestNotificationBySms";
            public const string SendEnrollmentFinishedNotification = "SendEnrollmentFinishedNotificationBySms";
            public const string SendReminderEnrollmentNotification = "SendReminderEnrollmentNotificationBySms";
        }

        public static class Email
        {
            public const string EnrollmentRequestNotification = "EnrollmentRequestNotificationByMail";
            public const string SendEnrollmentFinishedNotification = "SendEnrollmentFinishedNotificationByMail";
            public const string SendReminderEnrollmentNotification = "SendReminderEnrollmentNotificationByMail";
        }
        public const string StoreCustomerInformation = "StoreCustomerInformation";
        public const string UpdateEnrollmentStatus = "UpdateEnrollmentStatus";
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
