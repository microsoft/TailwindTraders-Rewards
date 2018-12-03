using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class UpdateStatus
    {
        public UpdateStatus(string customerID, string mobileNumber, EnrollmentStatusEnum status)
        {
            CustomerId = customerID;
            Status = status;
            MobileNumber = mobileNumber;
        }

        public string CustomerId { get; set; }
        public string MobileNumber { get; set; }
        public EnrollmentStatusEnum Status { get; set; }
    }
}
