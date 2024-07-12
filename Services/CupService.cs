using Microsoft.Data.SqlClient;
using Squad.Models;
using System.Diagnostics.Metrics;

namespace Squad.Services
{
    public static class CupService
    {
        public static List<Cup> Cups { get; }

        static CupService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Cups = new List<Cup>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT * FROM CUP ORDER BY YEAR DESC";
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
                        Cups.Add(new Cup(dr.GetString(0), dr.GetString(1)));
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
