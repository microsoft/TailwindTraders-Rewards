using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.WindowsAzure.Storage.Table;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class CustomerInfo : TableEntity
    {
        public string Phonenumber { get; set; }
        public string InstanceId { get; set; }
    }
}
