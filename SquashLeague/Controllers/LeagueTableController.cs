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

            LegaueTableResults model = new LegaueTableResults();
            model.Results = SquashLegaue.Repo.LeagueTableRepo.Get(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(LegaueTableResults Model)
        {
            ViewBag.Title = "The League table";
            ViewBag.Message = "Here are the current standings.";

            Model.Results = SquashLegaue.Repo.LeagueTableRepo.Get(Model);
            return View(Model);
        }

        [Authorize]
        public ActionResult AddResult()
        {
            ViewBag.Title = "Add Result";
            ViewBag.Message = "Add a result of a game";

            var model = new GameResult();
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

            return View(SquashLegaue.Repo.LeagueTableRepo.GetGames());
        }
    }
}
