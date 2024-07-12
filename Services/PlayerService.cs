using Microsoft.Data.SqlClient;
using Squad.Models;

namespace Squad.Services
{
    public static class PlayerService
    {
        public static List<Player> Players { get; }

        static PlayerService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Players = new List<Player>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT CODE,NAME,COUNTRYCODE,POSITION,PICTURE FROM PLAYER ORDER BY POSITION";
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
                        Players.Add(new Player(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4)));
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
