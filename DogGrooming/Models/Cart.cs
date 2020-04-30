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

        //public Cart(int cartId)
        //{
        //    CartId = cartId;
        //}

        //public void Add(Cart cart)
        //{
        //}

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

        //public List<Cart> GetCartServices()
        //{
        //    return db.Carts.Where(cart => cart.CartId == db.Carts).ToList();
        //}
        //public int CreateCart(Cart cart)
        //{
        //    var cartServices = GetCartServices();

        //    // Iterate over the items in the cart
        //    foreach (var item in cartServices)
        //    {
        //        var cartDetail = new CartDetail
        //        {
        //            ClientId = item.ClientId,
        //            CartId = cart.CartId,
        //        };
                
        //        db.CartServices.Add(cartServices);

        //    }
    }
}