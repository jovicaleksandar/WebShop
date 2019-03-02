using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class Product
    {
        public string id { get; set; }
        public string name { get; set; }
        public double price { get; set; }

        public Product() { }

        public Product(string id, string name, double price)
        {
            this.id = id;
            this.name = name;
            this.price = price;
        }
    }
}