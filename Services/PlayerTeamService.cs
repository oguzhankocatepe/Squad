using Microsoft.Data.SqlClient;
using Squad.Models;

namespace Squad.Services
{
    public static class PlayerTeamService
    {
        public static List<Team> Teams{ get; }

        static PlayerTeamService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Teams = new List<Team>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT TEAMLEAGUECODE , PLAYERCODE FROM TEAMLEAGUEPLAYER";
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
                        Teams.Add(new Team(dr.GetString(0), dr.GetString(1)));
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
