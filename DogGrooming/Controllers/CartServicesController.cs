﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DogGrooming.Models;

namespace DogGrooming.Controllers
{
    public class CartServicesController : Controller
    {
        private DogGroomingContext db = new DogGroomingContext();

        private static Cart myCart = new Cart();

        // GET: Cart
        public ActionResult Index(int id)
        {
            ViewBag.ClientId = id;


            double cartTotal = myCart.GetTotalCartPrice();
            ViewBag.CartTotal = cartTotal;
            //return View(products);
            return View(db.Services.ToList());
        }

        public ActionResult SelectServices(int id)
        {

            double cartTotal = myCart.GetTotalCartPrice();
            ViewBag.CartTotal = cartTotal;
            //return View(products);
            return View(db.Services.ToList());
        }

        // GET: Cart/Details/5
        public ActionResult Add(int code, int id)
        {
          
            Service serviceToAdd = db.Services.FirstOrDefault(p => p.Code.Equals(code));
            if (serviceToAdd != null)
            {
                myCart.AddService(serviceToAdd);
            }
            return RedirectToAction("Index", new { id = id });
        }

        public ActionResult GoToCart(int id)
        {
            Client client = db.Clients.Find(id);
            if (client != null)
            {
                ViewBag.DogName = client.DogName;
                ViewBag.Total = myCart.GetTotalCartPrice();
            }
                
            
            return View(myCart.services);
        }
    }
}
