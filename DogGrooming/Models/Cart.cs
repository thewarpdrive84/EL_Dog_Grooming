using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogGrooming.Models
{
        public class Cart
    {
        [Key]
        public int CartId { get; set; }

        public List<CartService> services;

        public Cart()
        {
            services = new List<CartService>();
        }

        public void AddService(Service serviceToAdd)
        {
            var match = services.FirstOrDefault(p => p.Code.Equals(serviceToAdd.Code));
            if (match == null)
            {
                services.Add(new CartService(serviceToAdd));
            }
            else
            {
                match.Quantity++;
            }
        }

        public double GetTotalCartPrice()
        {
            return services.Sum(itm => itm.Price * itm.Quantity);
        }
    }
}