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

    public class PlayerRepo
    {
        public static List<Player> GetList()
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlDataAdapter da = new SqlDataAdapter("select * from Players ORDER BY name", con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                List<Player> result = new List<Player>();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    result.Add(new Player()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Name = dr["Name"].ToString(),
                        Nickname = (dr["NickName"].ToString())
                    });
                }
                return result;
            }

            return null;
        }

        public static Player Get(int Id)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                SqlDataAdapter da = new SqlDataAdapter("select * from Players WHERE ID = " + Id, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                DataRow dr = ds.Tables[0].Rows[0];
                    return new Player()
                    {
                        Id = int.Parse(dr["Id"].ToString()),
                        Name = dr["Name"].ToString(),
                        Nickname = dr["NickName"].ToString(),
                        Email = dr["Email"].ToString()
                    };
                }
            }

            return null;
        }

        public static void Update(Player player)
        {
            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
                {
                    var sp = new SqlCommand("UpdatePlayer", con);
                    sp.CommandType = CommandType.StoredProcedure;
                    sp.Parameters.AddWithValue("ID", player.Id);
                    sp.Parameters.AddWithValue("Name", player.Name);
                    sp.Parameters.AddWithValue("Nickname", player.Nickname);
                    sp.Parameters.AddWithValue("email", player.Email);
                    con.Open();
                    sp.ExecuteNonQuery();
                }
            }
        }
    }
}