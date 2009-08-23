using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using One.ViewData;
using One.Services;
using One.Models;

namespace One.Controllers
{
    [HandleError]
    public class DefaultController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index(string section, int page)
        {
            if (page < 1)
                page = 1;

            if (!String.IsNullOrEmpty(section) && SectionCollection.ContainsSection(section))
            {
                ResponsePageViewData responsePageViewData = SectionCollection.Section(section).GetResponsePageViewData(page);
                responsePageViewData.SectionSummary = SectionCollection.GetSummary();

                return View("Section", responsePageViewData);
            }
            else
            {
                DefaultViewData defaultViewData = new DefaultViewData();
                defaultViewData.SectionSummary = SectionCollection.GetSummary();
                return View(defaultViewData);
            }

            
        }

        //[AcceptVerbs(HttpVerbs.Get)]
        //public ActionResult Paging(int page, long maxid)
        //{
        //    if (page < 1)
        //        page = 1;

        //    DefaultViewData viewData = new DefaultViewData();
        //    viewData.Question = Services.TwitterService.GetQuestion();
        //    viewData.Responses = Services.TwitterService.GetResponses(page, maxid);
        //    viewData.QuestionId = Services.TwitterService.QuestionId;
        //    viewData.NextGetQuestionDateTime = Services.TwitterService.NextGetQuestionDateTime;
        //    viewData.NextGetSearchResultDateTime = Services.TwitterService.NextGetSearchResultDateTime;
        //    return View("Index",viewData);
        //}
    }
}
