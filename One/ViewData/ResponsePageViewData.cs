using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using One.Models;

namespace One.ViewData
{
    public class ResponsePageViewData : BaseViewData
    {
        public string SectionName { get; set; }
        public string SectionColor { get; set; }
        public string Question { get; set; }
        public string QuestionHtmlEncoded { get; set; }
        public string QuestionTwitterfied { get; set; }
        public string CurrentPageHtml { get; set; }
        public string PreviousPageHtml { get; set; }
        public string NextPageHtml { get; set; }
        public List<ResponseViewData> Responses { get; set; }
        public DateTime QuestionRefreshedDate { get; set; }
        public string SectionResponsesTwitterHashTag { get; set; }
    }
}
