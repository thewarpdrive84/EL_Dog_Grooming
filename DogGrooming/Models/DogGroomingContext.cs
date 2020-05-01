using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DogGrooming.Models
{
    public class DogGroomingContext : DbContext
    {
        public DogGroomingContext() : base("name=DogGroomingContext")
        {
        }
        public System.Data.Entity.DbSet<DogGrooming.Models.Client> Clients { get; set; }

        public System.Data.Entity.DbSet<DogGrooming.Models.Service> Services { get; set; }

        public System.Data.Entity.DbSet<DogGrooming.Models.CartService> CartServices { get; set; }

        public System.Data.Entity.DbSet<DogGrooming.Models.Cart> Carts { get; set; }

    }
}