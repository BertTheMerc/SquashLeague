using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquashLegaue.Controllers
{
    using SquashLegaue.Models;
    using SquashLegaue.Repo;

    public class PlayerController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "The Players";
            ViewBag.Message = "Here are the players currently in the league.";
            
            return View(PlayerRepo.GetList());
        }

        [Authorize]
        public ActionResult Edit(int Id)
        {
            ViewBag.Title = "Edit player details";
            ViewBag.Message = "Please update the players details.";

            return View(PlayerRepo.Get(Id));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Edit(Player model)
        {
            if (ModelState.IsValid)
            {
                PlayerRepo.Update(model);
            }

            return RedirectToAction("Index", "Player");
        }
    }
}
