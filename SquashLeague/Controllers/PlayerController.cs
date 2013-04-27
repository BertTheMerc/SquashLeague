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

    public class PlayerController : Controller
    {
        private List<Player> table = new List<Player>();

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds = new DataSet();

        public ActionResult Index()
        {
            ViewBag.Title = "The Players";
            ViewBag.Message = "Here are the players currently in the league.";

            if (ConfigurationManager.ConnectionStrings["DefaultConnection"] != null)
            {
                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                da = new SqlDataAdapter("select * from Players ORDER BY name", con);
                da.Fill(ds);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    table.Add(new Player()
                    {
                        Name = dr["Name"].ToString(),
                        Nickname = (dr["NickName"].ToString())
                    });
                }
            }

            return View(table);
        }

    }
}
