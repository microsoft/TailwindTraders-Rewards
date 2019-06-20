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
            var query = string.Format("SELECT TOP {0} * FROM ORDERS", numberOfOrders);
            
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

        public static void AddOrder(Order order)
        {
            var query = @"INSERT INTO ORDERS
                                ([Code]
                                ,[Date]
                                ,[Type]
                                ,[ItemName]
                                ,[Status]
                                ,[Total])
                            VALUES
                                (@Code
                                ,@Date
                                ,@Type
                                ,@ItemName
                                ,@Status
                                ,@Total)";
                            

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Code", order.Code),
                new SqlParameter("@Date", order.Date),
                new SqlParameter("@Type", order.Type),
                new SqlParameter("@ItemName", order.ItemName),
                new SqlParameter("@Status", order.Status),
                new SqlParameter("@Total", order.Total)
            };

            try
            {
                DataAccessHandler.ExecuteNonSelect(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void UpdateOrder(Order order)
        {
            var query = @"UPDATE ORDERS
                                SET Code = @Code
                                ,Date = @Date
                                ,Type = @Type
                                ,ItemName = @ItemName
                                ,Status = @Status
                                ,Total = @Total
                            WHERE OrderId = @OrderId";
            
            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Code", order.Code),
                new SqlParameter("@Date", order.Date),
                new SqlParameter("@Type", order.Type),
                new SqlParameter("@ItemName", order.ItemName),
                new SqlParameter("@Status", order.Status),
                new SqlParameter("@Total", order.Total),
                new SqlParameter("@OrderId", order.OrderId)
            };

            try
            {
                DataAccessHandler.ExecuteNonSelect(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void DeleteOrder(int orderId)
        {
            var query = "DELETE FROM ORDERS WHERE OrderId = @OrderId";

            var param = new SqlParameter("@OrderId", orderId);

            try
            {
                DataAccessHandler.ExecuteNonSelect(query, new SqlParameter[] { param });
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