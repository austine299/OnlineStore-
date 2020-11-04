using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.Models;
using OnlineShoppingStore.Repository;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
        private dbMyOnlineStoreEntities db = new dbMyOnlineStoreEntities();

        // GET: Home
        private ICategoryRepository context = new CategoryRepository();
        // GET: ProductController
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Shop()
        {
            var products = db.Products.Include(p => p.Category);
            return View(products.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
    }
}
