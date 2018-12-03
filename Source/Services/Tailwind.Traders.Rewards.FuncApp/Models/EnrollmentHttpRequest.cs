using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class EnrollmentHttpRequest
    {
        private string _mobileNumber;

        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EnrollmentStatusEnum Enrolled { get; set; }
        public string MobileNumber
        {
            get => _mobileNumber;           
            set
            {
                _mobileNumber = Regex.Replace(value, @"\s", ""); ;
            }
        }

        public string InstanceId { get; set; }
    }
}
