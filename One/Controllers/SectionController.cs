using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Collections.Specialized;
using One.Models;

namespace One.Controllers
{
    public class SectionController : Controller
    {
        public ActionResult Index(string sectionName)
        {
            if (!SectionCollection.ContainsSection(sectionName))
                RedirectToAction("Index", "Default");


            return View();
        }
    }
}
