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

            var model = new Game(this.HttpContext.Application["Players"] as List<Player>);
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
                model.SetPlayers(this.HttpContext.Application["Players"] as List<Player>);
                ScheduleRepo.ScheduleGame(model);
                Twitter.Tweet(model.TwitterScheduled);
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit Scheduled game";
            ViewBag.Message = "Schedule a game to be edited";
            var model = ScheduleRepo.GetScheduledGame(Id, this.HttpContext.Application["Players"] as List<Player>);
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
                Twitter.Tweet(model.TwitterEdited);
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }
        
        public ActionResult ListScheduledGames()
        {
            ViewBag.Title = "The scheduled games";
            ViewBag.Message = "Here are the list of scheduled games";

            return View(SquashLegaue.Repo.ScheduleRepo.GetScheduledGames(this.HttpContext.Application["Players"] as List<Player>));
        }

        [Authorize]
        public ActionResult Delete(int Id)
        {
            if (ModelState.IsValid)
            {
                Game toBeDeleted = ScheduleRepo.GetScheduledGame(Id, this.HttpContext.Application["Players"] as List<Player>);
                ScheduleRepo.Delete(Id);
                Twitter.Tweet(toBeDeleted.TwitterDelete);                
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }

        [Authorize]
        public ActionResult Complete(int Id)
        {
            if (ModelState.IsValid)
            {
                var game = ScheduleRepo.GetScheduledGame(Id, this.HttpContext.Application["Players"] as List<Player>);

                ViewBag.Title = "Add Result";
                ViewBag.Message = "Add a result of a scheduled game";

                GameResult result = new GameResult(this.HttpContext.Application["Players"] as List<Player>);
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
                var game = ScheduleRepo.GetScheduledGame(model.ID, this.HttpContext.Application["Players"] as List<Player>);

                model.Player1SelectedItemId = game.Player1SelectedItemId;
                model.Player1 = game.Player1;
                model.Player2SelectedItemId = game.Player2SelectedItemId;
                model.Player2 = game.Player2;
                model.GameType = game.GameType;
                model.DateOfGame = game.DateOfGame;
                LeagueTableRepo.AddGame(model);

                ScheduleRepo.Delete(game.ID);
                Twitter.Tweet(model.TwitterCompleteScheduledGame);
            }

            return RedirectToAction("Index", "LeagueTable");
        }

    }
}
