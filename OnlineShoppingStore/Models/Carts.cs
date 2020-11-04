using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class Carts
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public Carts(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}