using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModuloPessoa.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloPessoa.Controllers.Tests
{
    [TestClass()]
    public class RegioesControllerTests
    {
        [TestMethod()]
        public void IndexTest()
        {
            var controller = new RegioesController();
            var result = (RedirectToRouteResult)controller.Details(-1);
            Assert.AreEqual("Index", result.Values["action"]);
        }
    }
}