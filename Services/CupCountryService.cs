using Microsoft.Data.SqlClient;
using Squad.Models;
using System.Diagnostics.Metrics;

namespace Squad.Services
{
    public static class CupCountryService
    {
        public static List<CupCountry> CupCountries { get; }

        static CupCountryService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            CupCountries = new List<CupCountry>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT CUPCODE,COUNTRYCODE FROM CUPCOUNTRY";
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
                        CupCountries.Add(new CupCountry(dr.GetString(0), dr.GetString(1)));
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
