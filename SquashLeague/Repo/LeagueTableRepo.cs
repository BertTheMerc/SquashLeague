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

    public class LeagueTableRepo
    {
        public static List<LeagueTable> Get()
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var table = new List<LeagueTable>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from vLeagueTable ORDER BY POINTS DESC, GamesDiff DESC", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        table.Add(new LeagueTable()
                        {
                            Name = dr["Name"].ToString(),
                            Matchs = int.Parse(dr["Matchs"].ToString()),
                            Win = int.Parse(dr["Win"].ToString()),
                            Draw = int.Parse(dr["Draw"].ToString()),
                            Lost = int.Parse(dr["Lost"].ToString()),
                            GamesWon = int.Parse(dr["GamesWon"].ToString()),
                            GamesLost = int.Parse(dr["GamesLost"].ToString()),
                            GamesDiff = int.Parse(dr["GamesDiff"].ToString()),
                            Points = int.Parse(dr["Points"].ToString()),
                            WinPercentage = int.Parse(dr["WinPercentage"].ToString())
                        });
                    }
                }
                return table;
            }
             
            return null;
        }

        public static List<GameResult> GetGames()
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var table = new List<GameResult>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from vResults ORDER BY Played", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        table.Add(new GameResult()
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            DateOfGame = DateTime.Parse(dr["Played"].ToString()),
                            Player1 = dr["Player1Name"].ToString(),
                            Player2 = dr["Player2Name"].ToString(),
                            Player1SelectedItemId = int.Parse(dr["Player1"].ToString()),
                            Player2SelectedItemId = int.Parse(dr["Player2"].ToString()),
                            Player1Score = int.Parse(dr["Player1Score"].ToString()),
                            Player2Score = int.Parse(dr["Player2Score"].ToString()),
                            GameType = dr["GameType"].ToString()
                        });
                    }
                }
                return table;
            }

            return null;
        }

        public static void AddGame(GameResult result) 
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("AddGame", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("DateOfGame", result.DateOfGame);
                    sp.Parameters.AddWithValue("Player1", result.Player1SelectedItemId);
                    sp.Parameters.AddWithValue("Player2", result.Player2SelectedItemId);
                    sp.Parameters.AddWithValue("Player1Score", result.Player1Score);
                    sp.Parameters.AddWithValue("Player2Score", result.Player2Score);
                    sp.Parameters.AddWithValue("GameType", result.GameType);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }        
        }

        public static void DeleteGame(int GameId)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("DeleteGame", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("GameId", GameId);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }
        }
    }
}