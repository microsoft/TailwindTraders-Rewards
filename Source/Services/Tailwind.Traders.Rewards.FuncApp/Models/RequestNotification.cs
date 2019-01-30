using System;
using System.Collections.Generic;
using System.Text;

namespace Tailwind.Traders.Rewards.FuncApp.Models
{
    public class RequestNotification
    {
        public RequestNotification(string instanceId, string mobileNumber, string email, string firstName, string lastName)
        {
            InstanceId = instanceId;
            MobileNumber = mobileNumber;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public string InstanceId { get; }
        public string MobileNumber { get; }

        public string Email { get;  }
        public string FirstName { get; }
        public string LastName { get; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
