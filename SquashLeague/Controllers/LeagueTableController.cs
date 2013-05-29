using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SquashLegaue.Controllers
{   
    using SquashLegaue.Models;
    using SquashLegaue.Repo;
    using SquashLegaue.BusinessObjects;

    public class LeagueTableController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "The League table";
            ViewBag.Message = "Here are the current standings.";

            return View(SquashLegaue.Repo.LeagueTableRepo.Get());
        }

        [Authorize]
        public ActionResult AddResult()
        {
            ViewBag.Title = "Add Result";
            ViewBag.Message = "Add a result of a game";

            var model = new GameResult(this.HttpContext.Application["Players"] as List<Player>);
            model.DateOfGame = DateTime.Today;

            if (string.IsNullOrWhiteSpace(model.GameType))
            {
                model.GameType = "L";
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult AddResult(GameResult model)
        {
            if (ModelState.IsValid)
            {
                model.SetPlayers(this.HttpContext.Application["Players"] as List<Player>);
                LeagueTableRepo.AddGame(model);
                Twitter.Tweet(model.TwitterResult);
            }

            return RedirectToAction("Index", "LeagueTable");
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                LeagueTableRepo.DeleteGame(Id);
            }

            return RedirectToAction("Index", "LeagueTable");
        }

        public ActionResult ListGames()
        {
            ViewBag.Title = "The League table";
            ViewBag.Message = "Here are the list of completed games";

            return View(SquashLegaue.Repo.LeagueTableRepo.GetGames(this.HttpContext.Application["Players"] as List<Player>));
        }
    }
}
