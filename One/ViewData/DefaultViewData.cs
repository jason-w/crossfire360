using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dimebrain.TweetSharp.Model;

namespace One.ViewData
{
    public class DefaultViewData
    {
        public string Question { get; set; }
        public TwitterSearchResult Responses { get; set; }
        public long QuestionId { get; set; }
        public DateTime NextGetQuestionDateTime { get; set; }
        public DateTime NextGetSearchResultDateTime { get; set; }
        public DateTime QuestionRefreshedDate { get; set; }
    }
}
