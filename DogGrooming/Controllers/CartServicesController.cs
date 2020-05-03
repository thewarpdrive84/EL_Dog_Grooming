using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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
            try
            {
                ViewBag.ClientId = id;

                double cartTotal = myCart.GetTotalCartPrice();
                ViewBag.CartTotal = cartTotal;
                return View(db.Services.ToList());
            }
            catch
            {
                return View();
            }
        }

        // Add service(s) to cart
        public ActionResult Add(int code, int id)
        {
            try
            {
                Service serviceToAdd = db.Services.FirstOrDefault(p => p.Code.Equals(code));
                if (serviceToAdd != null)
                {
                    myCart.AddService(serviceToAdd);
                }
                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

            // Go to client's cart
        public ActionResult GoToCart(int id)
        {
            try
            {
                Client client = db.Clients.Find(id);
                if (client != null)
                {
                    ViewBag.DogName = client.DogName;
                    ViewBag.Total = myCart.GetTotalCartPrice();
                }
                return View(myCart.services);
            }
            catch
            {
                return View();
            }
        }


        // Download invoice to txt file
        public FileStreamResult Invoice()
        {
            StringBuilder sb = new StringBuilder("Your Invoice");

                sb.AppendLine(" ");
                sb.AppendLine("Id:" + @ViewBag.ClientId);
                sb.AppendLine("Name:" + (string)(Session[@ViewBag.name]));
                sb.AppendLine("Total:" + @ViewBag.Total);

                var invoiceDetails = sb.ToString();

                var byteArray = Encoding.ASCII.GetBytes(invoiceDetails);
                var stream = new MemoryStream(byteArray);

                return File(stream, "text/plain", "Invoice.txt");
        }
    }
}
