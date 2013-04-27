using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace SquashLegaue.Controllers
{   
    using SquashLegaue.Models;

    public class LeagueTableController : Controller
    {
        private List<LeagueTable> table = new List<LeagueTable>();
        
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();
 
        public ActionResult Index()
        {
            ViewBag.Title = "The League table";
            ViewBag.Message = "Here are the current standings.";

            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                da = new SqlDataAdapter("select * from vLeagueTable ORDER BY POINTS DESC, GamesDiff DESC", con);
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
            return View(table);
        }

    }
}
