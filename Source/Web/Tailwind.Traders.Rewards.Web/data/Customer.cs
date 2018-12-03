using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tailwind.Traders.Rewards.Web.data
{
    public class Customer
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public int CustomerId { get; set; }
        public string AccountCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }
        public EnrollmentStatusEnum Enrrolled { get; set; }
        [Key]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
    }
}