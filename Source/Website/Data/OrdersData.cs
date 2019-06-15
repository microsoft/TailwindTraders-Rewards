using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tailwind.Traders.Rewards.Web.Models;

namespace Tailwind.Traders.Rewards.Web.Data
{
    public class OrdersData
    {
        public static IEnumerable<Order> GetOrders(int numberOfOrders = 5)
        {
            var query = "SELECT TOP 5 * FROM ORDERS";
            
            try
            {
                var result =  DataAccessHandler.ExecuteSelect(query);
                return GetMappedOrders(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Order> GetOrders(int customerId, int numberOfOrders = 5)
        {
            var query = "SELECT * FROM ORDERS WHERE CustomerId = @customerId";
            SqlParameter param = new SqlParameter("@customerId", customerId);

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query, new SqlParameter[] { param });
                return GetMappedOrders(result);
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public static IEnumerable<Order> GetOrdersRandomized()
        {
            var query = "SELECT TOP 5 * FROM ORDERS ORDER BY NEWID()";

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query);
                return GetMappedOrders(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static IEnumerable<Order> GetMappedOrders(DataTable ordersResult)
        {
            var mappedOrders = new List<Order>();
            foreach(DataRow row in ordersResult.Rows)
            {
                mappedOrders.Add(new Order
                {
                    Code = row["Code"].ToString(),
                    Date = (DateTime)row["Date"],
                    ItemName = row["ItemName"].ToString(),
                    OrderId = (int)row["OrderId"],
                    Status = row["Status"].ToString(),
                    Total = (decimal)row["Total"],
                    Type = row["Type"].ToString()
                });
            }

            return mappedOrders;
        }
    }
}