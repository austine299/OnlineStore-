using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        public ActionResult CategoryProduct(int id)
        {
            var category = iCategoryRepository.find(id);
            ViewBag.category = category;
            ViewBag.products= category.Products.ToList();
            return View("CategoryProduct");
        }
    }
}