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

    public class ScheduleRepo
    {
        public static List<Game> GetScheduledGames(List<Player> Players)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                var table = new List<Game>();
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from vScheduleGames ORDER BY ScheduledDate", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        table.Add(new Game(Players)
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            DateOfGame = DateTime.Parse(dr["ScheduledDate"].ToString()),                            
                            Player1SelectedItemId = int.Parse(dr["Player1"].ToString()),
                            Player2SelectedItemId = int.Parse(dr["Player2"].ToString()),
                            //Player1 = PlayerRepo.Get(int.Parse(dr["Player1"].ToString()),
                            //Player2 = PlayerRepo.Get(int.Parse(dr["Player2"].ToString()),
                            GameType = dr["GameType"].ToString()
                        });
                    }
                }
                return table;
            }

            return null;
        }

        public static Game GetScheduledGame(int ID, List<Player> Players)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    SqlDataAdapter da = new SqlDataAdapter("select * from vScheduleGames WHERE ID=" + ID, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        return (new Game(Players)
                        {
                            ID = int.Parse(dr["ID"].ToString()),
                            DateOfGame = DateTime.Parse(dr["ScheduledDate"].ToString()),
                            //Player1 = dr["Player1Name"].ToString(),
                            //Player2 = dr["Player2Name"].ToString(),
                            Player1SelectedItemId = int.Parse(dr["Player1"].ToString()),
                            Player2SelectedItemId = int.Parse(dr["Player2"].ToString()),
                            GameType = dr["GameType"].ToString()
                        });
                    }
                } 
                
                return null;
            }

            return null;
        }
        
        public static void ScheduleGame(Game result)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("ScheduleGame", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("DateOfGame", result.DateOfGame);
                    sp.Parameters.AddWithValue("Player1", result.Player1SelectedItemId);
                    sp.Parameters.AddWithValue("Player2", result.Player2SelectedItemId);
                    sp.Parameters.AddWithValue("GameType", result.GameType);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }
        }

        public static void EditScheduleGame(Game result)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("EditScheduleGame", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("ID", result.ID);
                    sp.Parameters.AddWithValue("DateOfGame", result.DateOfGame);
                    sp.Parameters.AddWithValue("Player1", result.Player1SelectedItemId);
                    sp.Parameters.AddWithValue("Player2", result.Player2SelectedItemId);
                    sp.Parameters.AddWithValue("GameType", result.GameType);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }
        }

        public static void Delete(int GameId)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("DeleteScheduledGame", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("GameId", GameId);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }
        }

    }
}