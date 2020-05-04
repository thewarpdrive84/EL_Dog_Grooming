using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

using DogGrooming;
using DogGrooming.Models;
using DogGrooming.Controllers;
using System.Web.Mvc;

namespace DogGrooming.Test
{
    [TestClass]
    public class DogGroomingUnitTests
    {
        //Client Tests:

        [TestMethod]
        public void CreateClient_Test()  //not passing due to error in date and time formats
        {
            Client client = new Client(12, "Emma", "River", "0873219875", "emma@thedodder.ie", new DateTime(2020, 07, 03 ), new DateTime(14, 00, 00));
        }

        [TestMethod()]
        public void CreateClientTestView()
        {
            var controller = new ClientsController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod()]
        public void EditClientTestView()
        {
            var controller = new ClientsController();
            var result = controller.Edit(4) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod()]
        public void DeleteClientTestView()
        {
            var controller = new ClientsController();
            var result = controller.Delete(5) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }


        //Service Tests

        [TestMethod]
        public void CreateService_Test()
        {
            Service service = new Service(20, "Tick Removal", 5);
        }


        [TestMethod()]
        public void CreateServiceTestView()
        {
            var controller = new ServicesController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod()]
        public void EditServiceTestView()
        {
            var controller = new ServicesController();
            var result = controller.Edit(3) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod()]
        public void DeleteServiceTestView()
        {
            var controller = new ServicesController();
            var result = controller.Delete(6) as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("", result.ViewName);
        }

    }
}
