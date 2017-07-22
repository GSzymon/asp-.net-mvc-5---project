using a1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace a1.DAL
{
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base("name=ProductsContext") { }

        public DbSet<Product> Product { get; set; }      
    }
}