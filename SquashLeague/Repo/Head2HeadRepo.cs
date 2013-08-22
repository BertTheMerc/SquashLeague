using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace SquashLegaue.Repo
{
    using SquashLegaue.Models;

    public class Head2HeadRepo
    {
        public static Head2Head Get(int Player1, int Player2)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var result = new Head2Head() { Player1SelectedItemId = Player1, Player2SelectedItemId = Player2 };
                var table = new List<LeagueTable>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("Head2HeadResults", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("@Player1Id", Player1);
                    sp.Parameters.AddWithValue("@Player2Id", Player2);

                    con.Open();
                    SqlDataReader data = sp.ExecuteReader();

                    while (data.Read())
                    {
                        result.NumberOfGames = int.Parse(data["Games"].ToString());
                        result.NumberOfDraws = int.Parse(data["Drawn"].ToString());
                        result.Player1Wins = int.Parse(data["Player1Won"].ToString());
                        result.Player1GamesWon = int.Parse(data["Player1GamesWon"].ToString());
                        result.Player2Wins = int.Parse(data["Player2Won"].ToString());
                        result.Player2GamesWon = int.Parse(data["Player2GamesWon"].ToString());
                    }
                    data.Close();
                }

                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("Head2HeadList", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("@Player1Id", Player1);
                    sp.Parameters.AddWithValue("@Player2Id", Player2);

                    con.Open();
                    SqlDataReader data = sp.ExecuteReader();

                    while (data.Read())
                    {
                        result.Games.Add(new GameResult()
                        {
                            Player1SelectedItemId = int.Parse(data["Player1"].ToString()),
                            Player2SelectedItemId = int.Parse(data["Player2"].ToString()),
                            Player1Score = int.Parse(data["Player1Score"].ToString()),
                            Player2Score = int.Parse(data["Player2Score"].ToString()),
                            DateOfGame = DateTime.Parse(data["Played"].ToString()),
                            Comments = data["Comments"].ToString()
                        });
                    }
                    data.Close();
                }
                return result;
            }
            return null;
        }
    }
}