using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using a1.DAL;
using a1.Models;

namespace a1.Controllers
{
    public class MainController : Controller
    {
        // GET: Main
        ProductsContext db = new ProductsContext();
        public ActionResult Main()
        {
            var namess = db.Product.Select(p => p.Name).ToList(); 
            ViewBag.names = namess;
            return View();
        }

        [HttpPost]
        public PartialViewResult ShowProducts(ProductDetalis details)
        {
            var productsTemp = db.Product.Where(k => (k.Name.ToString().Contains(details.Text)));
            List<Product> products1 = new List<Product>();
            List<Product> products2 = new List<Product>();

            foreach (Product p in productsTemp)
            {
                if (p.Name.ToUpper().StartsWith(details.Text.ToUpper()))
                {
                    products1.Add(p);
                }
                else
                {
                    products2.Add(p);
                }
            }
            ViewBag.list1 = products1;
            ViewBag.list2 = products2;
            ShoppingList list = new ShoppingList();
            return PartialView("_ShowProducts", list);
        }

        [HttpPost]
        public ActionResult ListDone(Object[] param)
        {
            return RedirectToAction("ShowList", "SummaryController", param);
        }
    }
}