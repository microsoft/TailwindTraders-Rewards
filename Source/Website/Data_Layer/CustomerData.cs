using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Tailwind.Traders.Rewards.Web.Models;

namespace Tailwind.Traders.Rewards.Web.Data
{
    public class CustomerData
    {
        public static Customer GetDefaultCustomer()
        {
            var query = "SELECT TOP 1 * FROM CUSTOMERS";

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query);
                return GetMappedCustomer(result.Rows[0]);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static Customer GetCustomerById(int customerId)
        {
            var query = "SELECT TOP 1 * FROM CUSTOMERS WHERE CustomerId = @customerId";
            var param = new SqlParameter("@customerId", customerId);

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query, new SqlParameter[] { param });

                if (result.Rows.Count > 0 && result.Rows[0] != null)
                {
                    return GetMappedCustomer(result.Rows[0]);
                }

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
        public static Customer GetCustomerByEmailOrName(string emailOrName)
        {
            var query = "SELECT TOP 1 * FROM CUSTOMERS WHERE FirstName = @emailOrName OR Email = @emailOrName";
            var param = new SqlParameter("@emailOrName", emailOrName);

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query, new SqlParameter[] { param });

                if(result.Rows.Count > 0 && result.Rows[0] != null)
                {
                    return GetMappedCustomer(result.Rows[0]);
                }

                return null;
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static IEnumerable<Customer> GetCustomers()
        {
            var query = string.Format("SELECT * FROM CUSTOMERS");

            try
            {
                var result = DataAccessHandler.ExecuteSelect(query);
                return GetMappedCustomers(result);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ChangeEnrollmentStatus(Customer customer)
        {
            var query = "UPDATE CUSTOMERS SET ENRROLLED = @enrollmentStatus where CustomerId = @customerId";

            var enrollmentParam = new SqlParameter("@enrollmentStatus", (int)customer.Enrrolled);
            var customerIdParam = new SqlParameter("@customerId", customer.CustomerId);
            var parameters = new SqlParameter[] { enrollmentParam, customerIdParam };

            try
            {
                DataAccessHandler.ExecuteNonSelect(query, parameters);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void AddCustomer(Customer customer)
        {
            var query = @"INSERT INTO CUSTOMERS
                                    (Email
                                    ,AccountCode
                                    ,FirstName
                                    ,LastName
                                    ,FirstAddress
                                    ,City
                                    ,Country
                                    ,ZipCode
                                    ,Website
                                    ,Active
                                    ,Enrrolled
                                    ,PhoneNumber
                                    ,MobileNumber
                                    ,FaxNumber)
                                VALUES
                                    (@Email
                                    ,@AccountCode
                                    ,@FirstName
                                    ,@LastName
                                    ,@FirstAddress
                                    ,@City
                                    ,@Country
                                    ,@ZipCode
                                    ,@Website
                                    ,@Active
                                    ,@Enrrolled
                                    ,@PhoneNumber
                                    ,@MobileNumber
                                    ,@FaxNumber)";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", customer.Email),
                new SqlParameter("@AccountCode", customer.AccountCode),
                new SqlParameter("@FirstName", customer.FirstName),
                new SqlParameter("@LastName", customer.LastName),
                new SqlParameter("@FirstAddress", customer.FirstAddress),
                new SqlParameter("@City", customer.City),
                new SqlParameter("@Country", customer.Country),
                new SqlParameter("@ZipCode", customer.ZipCode),
                new SqlParameter("@Website", customer.Website),
                new SqlParameter("@Active", (bool) customer.Active),
                new SqlParameter("@Enrrolled", (int) customer.Enrrolled),
                new SqlParameter("@PhoneNumber", customer.PhoneNumber),
                new SqlParameter("@MobileNumber", customer.MobileNumber),
                new SqlParameter("@FaxNumber", customer.FaxNumber)
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

        public static void UpdateCustomer(Customer customer)
        {
            var query = @"UPDATE CUSTOMERS
                            SET Email = @Email
                            ,AccountCode = @AccountCode
                            ,FirstName = @FirstName
                            ,LastName = @LastName
                            ,FirstAddress = @FirstAddress
                            ,City = @City
                            ,Country = @Country
                            ,ZipCode = @ZipCode
                            ,Website = @Website
                            ,Active = @Active
                            ,Enrrolled = @Enrrolled
                            ,PhoneNumber = @PhoneNumber
                            ,MobileNumber = @MobileNumber
                            ,FaxNumber = @FaxNumber
                        WHERE CustomerId = @CustomerId";

            var parameters = new SqlParameter[]
            {
                new SqlParameter("@Email", customer.Email),
                new SqlParameter("@AccountCode", customer.AccountCode),
                new SqlParameter("@FirstName", customer.FirstName),
                new SqlParameter("@LastName", customer.LastName),
                new SqlParameter("@FirstAddress", customer.FirstAddress),
                new SqlParameter("@City", customer.City),
                new SqlParameter("@Country", customer.Country),
                new SqlParameter("@ZipCode", customer.ZipCode),
                new SqlParameter("@Website", customer.Website),
                new SqlParameter("@Active", (bool) customer.Active),
                new SqlParameter("@Enrrolled", (int) customer.Enrrolled),
                new SqlParameter("@PhoneNumber", customer.PhoneNumber),
                new SqlParameter("@MobileNumber", customer.MobileNumber),
                new SqlParameter("@FaxNumber", customer.FaxNumber),
                new SqlParameter("@CustomerId", customer.CustomerId)
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

        public static void DeleteCustomer(int customerId)
        {
            var query = "DELETE FROM CUSTOMERS WHERE CustomerId = @CustomerId";

            var param = new SqlParameter("@CustomerId", customerId);

            try
            {
                DataAccessHandler.ExecuteNonSelect(query, new SqlParameter[] { param });
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static Customer GetMappedCustomer(DataRow customerRow)
        {
            return new Customer
            {
                AccountCode = customerRow["AccountCode"].ToString(),
                Active = (bool)customerRow["Active"],
                City = customerRow["City"].ToString(),
                Country = customerRow["Country"].ToString(),
                CustomerId = (int)customerRow["CustomerId"],
                Email = customerRow["Email"].ToString(),
                Enrrolled = (EnrollmentStatusEnum)customerRow["Enrrolled"],
                FaxNumber = customerRow["FaxNumber"].ToString(),
                FirstAddress = customerRow["FirstAddress"].ToString(),
                FirstName = customerRow["FirstName"].ToString(),
                LastName = customerRow["LastName"].ToString(),
                MobileNumber = customerRow["MobileNumber"].ToString(),
                PhoneNumber = customerRow["PhoneNumber"].ToString(),
                RowVersion = (byte[])customerRow["RowVersion"],
                Website = customerRow["Website"].ToString(),
                ZipCode = customerRow["ZipCode"].ToString()
            };
        }

        private static IEnumerable<Customer> GetMappedCustomers(DataTable customersResult)
        {
            var mappedCustomers = new List<Customer>();
            foreach (DataRow row in customersResult.Rows)
            {
                mappedCustomers.Add(GetMappedCustomer(row));
            }

            return mappedCustomers;
        }
    }
}