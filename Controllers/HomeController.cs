using a1.DAL;
using a1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace a1.Controllers
{
    public class HomeController : Controller
    {
        //private ProductsContext db = new ProductsContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}