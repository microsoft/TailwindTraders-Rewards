using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class RequestNotification
    {
        public RequestNotification(string instanceId, string mobileNumber)
        {
            InstanceId = instanceId;
            MobileNumber = mobileNumber;
        }

        public string InstanceId { get; set; }
        public string MobileNumber { get; set; }
    }
}
