using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace One.ViewData
{
    public class SectionSummaryViewData
    {
        public string SectionName { get; set; }
        public string SectionQuestion { get; set; }
        public string SectionColor { get; set; }
        public List<ResponseViewData> Responses { get; set; }
    }
}
