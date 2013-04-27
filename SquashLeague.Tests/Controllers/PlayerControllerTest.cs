using System;
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
    public class PlayerControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.AreEqual("Player Index", result.ViewBag.Title);
        }
    }
}
