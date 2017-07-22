using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace a1.Controllers
{
    public class SummaryController : Controller
    {
        // GET: Summary
        public ActionResult ShowList(List<String> list)
        {
            //EmailSender sender = new EmailSender(list);
            ViewBag.list = list;
            return View();
        }
    }
}