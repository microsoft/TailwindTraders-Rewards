using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Tailwind.Traders.Rewards.Web.Data
{
    public class DataAccessHandler
    {
        public static DataTable ExecuteSelect(string query, SqlParameter[] parameters = null)
        {
            DataTable table = new DataTable();

            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["dbContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        dataAdapter.Fill(table);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return table;
        }

        public static void ExecuteNonSelect(string query, SqlParameter[] parameters = null)
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["dbContext"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    if (parameters != null)
                    {
                        command.Parameters.AddRange(parameters);
                    }

                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}