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
            Client client = new Client(12, "Emma", "River", "0873219875", "emma@thedodder.ie", new DateTime(2020, 07, 03), new DateTime(14, 00, 00));
        }

        [TestMethod()]
        public void CreateClientTestView()
        {
            var controller = new ClientsController();
            var result = controller.Create() as ViewResult;
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

        [TestMethod]
        public void TestRemove()
        {
            Service service1 = new Service() { Code = 25, Description = "Tail Braiding", Price = 15 };
            Service service2 = new Service() { Code = 26, Description = "Flea Treatment", Price = 5 }; 
            Cart cart = new Cart();
            cart.AddService(service1);
            cart.AddService(service2);
            cart.AddService(service2);

            cart.RemoveService(service2);
            cart.RemoveService(service1);

            List<CartService> services = new List<CartService>(cart.services);
            Assert.AreEqual(services.Count, 1);
            Assert.AreEqual(services[0].Quantity, 1);
            Assert.AreEqual(services[0].Code, service2.Code);
        }


        [TestMethod]
        public void GetTotalCartPrice_Test()
        {
            // test logic to total price for items in cart
            Service service1 = new Service() { Code = 25, Description = "Tail Braiding", Price = 15 };
            Service service2 = new Service() { Code = 26, Description = "Flea Treatment", Price = 5 };
            Cart cart = new Cart();
            cart.AddService(service1);
            cart.AddService(service2);

            Assert.AreEqual(cart.GetTotalCartPrice(), service1.Price + service2.Price);
        }


    }
}
