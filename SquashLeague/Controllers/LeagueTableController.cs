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
                model.Player1 = model.PlayerList.Single(x => x.Value == model.Player1SelectedItemId.ToString()).Text;
                model.Player2 = model.PlayerList.Single(x => x.Value == model.Player2SelectedItemId.ToString()).Text;

                LeagueTableRepo.AddGame(model);
                Twitter.Tweet(string.Format("GAME RESULT: Result of the Game with {0} & {1} is {2}-{3}.", model.Player1, model.Player2, model.Player1Score, model.Player2Score));
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
