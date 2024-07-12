using Microsoft.Data.SqlClient;
using Squad.Models;

namespace Squad.Services
{
    public static class CupPlayerService
    {
        public static List<CupPlayer> Players { get; }

        static CupPlayerService()
        {
            string connString = @"Server =.; Database = SQUAD; Trusted_Connection = True; TrustServerCertificate=True;";
            Players = new List<CupPlayer>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"SELECT CUPCOUNTRYPLAYER.CUPCOUNTRYCODE, PLAYER.CODE ,NAME,COUNTRYCODE,POSITION,PICTURE FROM PLAYER 
                                INNER JOIN CUPCOUNTRYPLAYER ON PLAYER.CODE = CUPCOUNTRYPLAYER.PLAYERCODE ORDER BY POSITION";
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
                        Players.Add(new CupPlayer(dr.GetString(0), dr.GetString(1), dr.GetString(2), dr.GetString(3), dr.GetString(4), dr.GetString(5)));
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
