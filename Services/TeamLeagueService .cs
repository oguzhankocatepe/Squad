using Microsoft.Data.SqlClient;
using Squad.Models;

namespace Squad.Services
{
    public static class TeamLeagueService
    {
        public static List<League> Leagues { get; }

        static TeamLeagueService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Leagues = new List<League>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT TEAMCODE , LEAGUECODE FROM TEAMLEAGUE";
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
                        Leagues.Add(new League(dr.GetString(0), dr.GetString(1)));
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
