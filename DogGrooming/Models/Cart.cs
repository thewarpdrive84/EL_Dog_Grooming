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

        //cart constructor
        public Cart()
        {
            services = new List<CartService>();
        }

        //add service to cart and increase quantity
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

        //remove service to cart and decrease quantity
        public void RemoveService(Service serviceToRemove)
        {
            var match = services.FirstOrDefault(p => p.Code.Equals(serviceToRemove.Code));
            if (match == null)
            {
                services.Remove(new CartService(serviceToRemove));
            }
            else
            {
                match.Quantity--;
            }
        }

        //calculate the total price of services in cart
        public double GetTotalCartPrice()
        {
            return services.Sum(itm => itm.Price * itm.Quantity);
        }
    }
}