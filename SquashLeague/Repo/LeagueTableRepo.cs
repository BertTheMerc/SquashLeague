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
        public static List<LeagueResultType> ResultTypes()
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var resultTypes = new List<LeagueResultType>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlDataAdapter da;
                    da = new SqlDataAdapter("SELECT ID, Name, Selector FROM LeagueResultTypes", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        resultTypes.Add(new LeagueResultType()
                        {
                            ID = int.Parse(dr["id"].ToString()),
                            Name = dr["Name"].ToString(),
                            Selector = dr["selector"].ToString()
                        });
                    }
                }
                return resultTypes;
            }

            return null;
        }
        public static List<LeagueTable> Get(LegaueTableResults Result)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var table = new List<LeagueTable>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    string sql = string.Format("SELECT * FROM {0} ORDER BY {1}", (Result.LeagueData) ? "vLeagueTable" : "vLadderTable", Result.ActiveResultType.Selector);
                    SqlDataAdapter da;

                    da = new SqlDataAdapter(sql, con); 
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
                            Player1SelectedItemId = int.Parse(dr["Player1"].ToString()),
                            Player2SelectedItemId = int.Parse(dr["Player2"].ToString()),
                            Player1Score = int.Parse(dr["Player1Score"].ToString()),
                            Player2Score = int.Parse(dr["Player2Score"].ToString()),
                            GameType = dr["GameType"].ToString(),
                            Comments = dr["Comments"].ToString()
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
                    sp.Parameters.AddWithValue("Comments", result.Comments);
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