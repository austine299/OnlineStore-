using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Models.Home
{
    public class HomeIndexViewModel
    {
        public List<Category> Categories { get; set; }
        public List<Product> FeaturedProducts { get; set; }
    }
}