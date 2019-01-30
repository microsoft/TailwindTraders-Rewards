using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class UpdateStatus
    {
        public UpdateStatus(string customerID, string mobileNumber, EnrollmentStatusEnum status, string email)
        {
            CustomerId = customerID;
            Status = status;
            MobileNumber = mobileNumber;
            Email = email;
        }

        public string Email { get; }

        public string CustomerId { get; }
        public string MobileNumber { get; }
        public EnrollmentStatusEnum Status { get; }
    }
}
