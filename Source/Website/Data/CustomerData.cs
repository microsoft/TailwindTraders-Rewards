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
            catch (System.Exception e)
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
            catch (System.Exception e)
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
            catch (System.Exception e)
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
            catch (System.Exception e)
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
    }
}