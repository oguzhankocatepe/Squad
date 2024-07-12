using Microsoft.Data.SqlClient;
using Squad.Models;
using System.Diagnostics.Metrics;

namespace Squad.Services
{
    public static class CountryService
    {
        public static List<Country> Countries { get; }

        static CountryService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Countries = new List<Country>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT * FROM COUNTRY";
                //define the SqlCommand object
                SqlCommand cmd = new SqlCommand(query, conn);

                //open connection
                conn.Open();

                //execute the SQLCommand
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Countries.Add(new Country(dr.GetString(0), dr.GetString(1), dr.GetString(2)));
                    }
                }
                //close data reader
                dr.Close();

                //close connection
                conn.Close();
            }
        }
    }
}
