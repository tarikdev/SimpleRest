using Coolblue.Assigment.DAL.Entities;
using CoolblueAssigment.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolblueAssigment.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public void Get()
        {
            ProductController controller = new ProductController();

            var result = controller.Get() as List<Product>;
            Assert.AreEqual(3, result.Count);            
        }
    }
}
