using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquashLegaue.Controllers
{
    using SquashLegaue.Models;
    using SquashLegaue.Repo;

    public class ScheduleController : Controller
    {
        [Authorize]
        public ActionResult ScheduleGame()
        {
            ViewBag.Title = "Schedule";
            ViewBag.Message = "Schedule a game to be played";

            var model = new Game();
            model.DateOfGame = DateTime.Today;

            return View(model);
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
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult ScheduleGame(Game model)
        {
            if (ModelState.IsValid)
            {
                ScheduleRepo.ScheduleGame(model);
            }

            return RedirectToAction("Index", "LeagueTable");
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
                ScheduleRepo.Delete(Id);
            }

            return RedirectToAction("ListScheduledGames", "Schedule");
        }
    }
}
