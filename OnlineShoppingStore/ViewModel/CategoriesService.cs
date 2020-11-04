using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.ViewModel
{
    public class CategoriesService
    {


        public List<Product> FeaturedProducts()
        {
            using(var context= new dbMyOnlineStoreEntities())
            {
                return context.Products.ToList();
            }
        }
        public Category GetCategory(int Id)
        {
            using(var context=new dbMyOnlineStoreEntities())
            {
                return context.Categories.Find(Id);
            }
        }
        public List<Category> GetCategory()
        {
            using (var context = new dbMyOnlineStoreEntities())
            {
                return context.Categories.ToList();
            }
        }
        public List<Category> GetFeaturedGetCategory()
        {
            using (var context = new dbMyOnlineStoreEntities())
            {
                return context.Categories.ToList();
            }
        }
    }
}