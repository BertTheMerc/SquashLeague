using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SquashLegaue.Controllers
{
    using SquashLegaue.Models;
    using SquashLegaue.Repo;

    public class Head2HeadController : Controller
    {
        //
        // GET: /Head2Head/

        public ActionResult Index()
        {
            var model = Head2HeadRepo.Get(1, 4);

            return View(model);
        }

    }
}
