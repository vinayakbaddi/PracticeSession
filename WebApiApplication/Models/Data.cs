using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiApplication.Models
{
    public static class Data
    {

        private static Product[] Products = new Product[] 
        { 
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 }, 
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M }, 
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M } 
        };

        public static IEnumerable<Product> GetProducts()
        {
            return Products;
        }
    }
}