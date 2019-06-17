using System;

namespace Tailwind.Traders.Rewards.Web.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string  ItemName { get; set; }
        public string Status { get; set; }
        public decimal Total { get; set; }
    }
}