using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DogGrooming.Models
{
    public class Service
    {
        [Key]
        public int Code { get; set; }
        public String Description { get; set; }

        [Display(Name = "Price (€)")]
        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public Service(int _code, String _description, double _price)
        {
            Code = _code;
            Description = _description;
            Price = _price;
        }

        public Service()
        {

        }
    }

    public class CartService : Service
    {
       
        public int Quantity { get; set; }

        public CartService(Service srv) : base(srv.Code, srv.Description, srv.Price)
        {
            Quantity = 1;
        }

        public CartService()
        {
        }
    }
}