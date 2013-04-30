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

    public class ScheduleController : Controller
    {
        [Authorize]
        public ActionResult ScheduleGame()
        {
            ViewBag.Title = "Schedule";
            ViewBag.Message = "Schedule a game to be played";

            var model = new Game();
            model.DateOfGame = DateTime.Today;
            model.GameType = "L";

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ScheduleGame(Game model)
        {
            if (ModelState.IsValid)
            {

                model.Player1 = model.PlayerList.Single(x => x.Value == model.Player1SelectedItemId.ToString()).Text;
                model.Player2 = model.PlayerList.Single(x => x.Value == model.Player2SelectedItemId.ToString()).Text;
                ScheduleRepo.ScheduleGame(model);

                Twitter.Tweet(string.Format("SCHEDULE: {0} to play {1} as a {2} game on the {3}", model.Player1, model.Player2, model.GameTypeDisplay, model.DateOfGame.ToLongDateString()));
            }

            return RedirectToAction("Index", "LeagueTable");
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Scheduled game";
            ViewBag.Message = "Schedule a game to be edited";
            var model = ScheduleRepo.GetScheduledGame(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(Game model)
        {
            if (ModelState.IsValid)
            {
                ScheduleRepo.EditScheduleGame(model);

                Twitter.Tweet(string.Format("SCHEDULE UPDATE: {0} to play {1} as a {2} game on the {3}", model.Player1, model.Player2, model.GameTypeDisplay, model.DateOfGame.ToLongDateString()));
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }
        
        public ActionResult ListScheduledGames()
        {
            ViewBag.Title = "The scheduled games";
            ViewBag.Message = "Here are the list of scheduled games";

            return View(SquashLegaue.Repo.ScheduleRepo.GetScheduledGames());
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                Game toBeDeleted = ScheduleRepo.GetScheduledGame(Id);
                ScheduleRepo.Delete(Id);
                Twitter.Tweet(string.Format("SCHEDULE UPDATE: Game with {0} & {1} on the {2} has been cancelled.", toBeDeleted.Player1, toBeDeleted.Player2, toBeDeleted.DateOfGame.ToLongDateString()));
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }

        [Authorize]
        public ActionResult Complete(int Id)
        {
            if (ModelState.IsValid)
            {
                var game = ScheduleRepo.GetScheduledGame(Id);

                ViewBag.Title = "Add Result";
                ViewBag.Message = "Add a result of a scheduled game";

                GameResult result = new GameResult();
                result.DateOfGame = game.DateOfGame;
                result.Player1SelectedItemId = game.Player1SelectedItemId;
                result.Player1 = game.Player1;
                result.Player2SelectedItemId = game.Player2SelectedItemId;
                result.Player2 = game.Player2;
                result.GameType = game.GameType;

                return View(result);
            }

            return RedirectToAction("ListScheduleGames", "Schedule");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Complete(GameResult model)
        {
            if (ModelState.IsValid)
            {
                var game = ScheduleRepo.GetScheduledGame(model.ID);

                model.Player1SelectedItemId = game.Player1SelectedItemId;
                model.Player1 = game.Player1;
                model.Player2SelectedItemId = game.Player2SelectedItemId;
                model.Player2 = game.Player2;
                model.GameType = game.GameType;
                model.DateOfGame = game.DateOfGame;
                LeagueTableRepo.AddGame(model);

                ScheduleRepo.Delete(game.ID);
                Twitter.Tweet(string.Format("GAME RESULT: Result of the {4} game with {0} & {1} is {2}-{3}.", model.Player1, model.Player2, model.Player1Score, model.Player2Score, model.GameTypeDisplay));
            }

            return RedirectToAction("Index", "LeagueTable");
        }

    }
}
