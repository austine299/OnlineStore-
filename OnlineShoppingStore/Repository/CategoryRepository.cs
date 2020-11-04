using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private dbMyOnlineStoreEntities context = new dbMyOnlineStoreEntities();
        public List<Category> findAll()
        {
            return context.Categories.ToList();
        }

        public Category find(int id)
        {
            return context.Categories.Find(id);
        }

    }
}