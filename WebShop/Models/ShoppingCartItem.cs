using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebShop.Models
{
    public class ShoppingCartItem
    {
        public Product product { get; set; }
        public int count { get; set; }
        public double total
        {
            get
            {
                return product.price * count;
            }
        }

        public ShoppingCartItem() { }

        public ShoppingCartItem(Product product, int count)
        {
            this.product = product;
            this.count = count;
        }
    }
}