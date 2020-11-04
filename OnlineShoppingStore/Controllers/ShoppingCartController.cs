using OnlineShoppingStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        dbMyOnlineStoreEntities db = new dbMyOnlineStoreEntities();
        private string strCart = "Cart";
        // GET: ShoppingCart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult OrderNow(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (Session[strCart] == null)
            {
                List<Carts> IsCart = new List<Carts>
                {
                    new Carts(db.Products.Find(id),1)
                };
                Session[strCart] = IsCart;
            }
            else
            {
                List<Carts> IsCart = (List<Carts>)Session[strCart];
                int check = isExistingCheck(id);
                if (check == -1)

                    IsCart.Add(new Carts(db.Products.Find(id), 1));
                else

                    IsCart[check].Quantity++;
                Session[strCart] = IsCart;
            }
            return View("Index");
        }
        private int isExistingCheck(int? id)
        {
            List<Carts> IsCart = (List<Carts>)Session[strCart];
            for (int i = 0; i < IsCart.Count; i++)
            {
                if (IsCart[i].Product.ProductId == id) return i;
            }
            return -1;
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            int check = isExistingCheck(id);
            List<Carts> IsCart = (List<Carts>)Session[strCart];
            IsCart.RemoveAt(check);
            return View("Index");
        }
    }
}