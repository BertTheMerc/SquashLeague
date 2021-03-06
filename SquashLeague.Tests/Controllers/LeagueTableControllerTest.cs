﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SquashLegaue;
using SquashLegaue.Controllers;

namespace SquashLegaue.Tests.Controllers
{
    [TestClass]
    public class LeagueTableControllerTest
    {
       
        public void Index()
        {
            // Arrange
            LeagueTableController controller = new LeagueTableController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Here are the current standings.", result.ViewBag.Message);
        }
    }
}
