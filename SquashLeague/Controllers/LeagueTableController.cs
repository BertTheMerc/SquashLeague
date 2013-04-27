﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace SquashLegaue.Controllers
{   
    using SquashLegaue.Models;
    using SquashLegaue.Repo;

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
