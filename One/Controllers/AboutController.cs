using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using One.ViewData;
using One.Models;

namespace One.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index(string section)
        {
            string view = "index";

            switch (section.ToUpper())
            {
                case "PRIVACY-POLICY":
                    view = "PrivacyPolicy";
                    break;
                case "TERMS-OF-SERVICE":
                    view = "TermsOfService";
                    break;
                case "COPYRIGHT":
                    view = "Copyright";
                    break;
            }

            AboutViewData aboutViewData = new AboutViewData();
            aboutViewData.SectionSummary = SectionCollection.GetSummary();
            return View(view, aboutViewData);
        }

    }
}
