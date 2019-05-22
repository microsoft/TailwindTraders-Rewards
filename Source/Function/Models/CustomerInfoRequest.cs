using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class CustomerInfoRequest
    {
        public CustomerInfoRequest(string phoneNumber, string instanceId, string customerId)
        {
            Phonenumber = phoneNumber;
            InstanceId = instanceId;
            CustomerId = customerId;
        }
        public string Phonenumber { get; set; }
        public string InstanceId { get; set; }
        public string CustomerId { get; set; }
    }
}
