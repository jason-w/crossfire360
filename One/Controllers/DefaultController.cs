using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using One.ViewData;
using One.Services;

namespace One.Controllers
{
    [HandleError]
    public class DefaultController : Controller
    {
        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            DefaultViewData viewData = new DefaultViewData();
            viewData.Question = Services.TwitterService.GetQuestion();
            viewData.Responses = Services.TwitterService.GetResponses(1, long.MinValue);
            viewData.QuestionId = Services.TwitterService.QuestionId;
            viewData.NextGetQuestionDateTime = Services.TwitterService.NextGetQuestionDateTime;
            viewData.NextGetSearchResultDateTime = Services.TwitterService.NextGetSearchResultDateTime;

            if (DateTime.Now.Hour >= 22)
                viewData.QuestionRefreshedDate = DateTime.Today;
            else
                viewData.QuestionRefreshedDate = DateTime.Today.AddDays(-1);

            return View(viewData);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Paging(int page, long maxid)
        {
            if (page < 1)
                page = 1;

            DefaultViewData viewData = new DefaultViewData();
            viewData.Question = Services.TwitterService.GetQuestion();
            viewData.Responses = Services.TwitterService.GetResponses(page, maxid);
            viewData.QuestionId = Services.TwitterService.QuestionId;
            viewData.NextGetQuestionDateTime = Services.TwitterService.NextGetQuestionDateTime;
            viewData.NextGetSearchResultDateTime = Services.TwitterService.NextGetSearchResultDateTime;
            return View("Index",viewData);
        }
    }
}
