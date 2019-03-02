using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShop.Models;

namespace WebShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            ShoppingCart sc = (ShoppingCart)Session["sc"];

            if (sc == null)
            {
                sc = new ShoppingCart();
                Session["sc"] = sc;
            }

            ViewBag.sc = sc;

            return View();
        }

        [HttpPost]
        public ActionResult Add(ShoppingItemsToAdd item)
        {
            Products products = (Products)HttpContext.Application["products"];
            ShoppingCart sc = (ShoppingCart)Session["sc"];

            if (sc == null)
            {
                sc = new ShoppingCart();
                Session["sc"] = sc;
            }

            if (!item.id.Equals("") && !item.count.Equals(""))
            {
                sc.Add(new ShoppingCartItem(products.collection[item.id], item.count));
            }

            ViewBag.sc = sc;

            return View("Index");
        }

        [HttpGet]
        public ActionResult NewProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewProduct(string id, string name, string price)
        {
            Products products = HttpContext.Application["products"] as Products;

            Product product = new Product(id, name, Double.Parse(price));

            products.collection.Add(product.id, product);

            HttpContext.Application["products"] = products;

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Rename(string id, string rename)
        {
            Products products = HttpContext.Application["products"] as Products;

            products.collection[id].name = rename;

            HttpContext.Application["products"] = products;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Update(string id)
        {
            ViewBag.id = id;

            return View();
        }

        [HttpPost]
        public ActionResult Update(string id, string name, string price)
        {
            Products products = HttpContext.Application["products"] as Products;

            products.collection[id].name = name;
            Double.TryParse(price, out double result);
            products.collection[id].price = result;

            HttpContext.Application["products"] = products;

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Delete(string id)
        {
            Products products = HttpContext.Application["products"] as Products;
            products.collection.Remove(id);
            HttpContext.Application["products"] = products;

            return RedirectToAction("Index", "Home");
        }
    }
}