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

        //service constructor
        public Service(int _code, String _description, double _price)
        {
            Code = _code;
            Description = _description;
            Price = _price;
        }

        //empty service constructor
        public Service()
        {

        }
    }

    //inherited class from service
    public class CartService : Service
    {
        public int Quantity { get; set; }

        // cartservice constuctor for quantity
        public CartService(Service srv) : base(srv.Code, srv.Description, srv.Price)
        {
            Quantity = 1;
        }

        //empty cartservice constructor
        public CartService()
        {
        }
    }
}