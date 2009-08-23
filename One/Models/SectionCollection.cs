using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using One.Services;
using One.ViewData;

namespace One.Models
{
    public static class SectionCollection
    {
        private static SortedDictionary<string, Section> _cachedSections = new SortedDictionary<string, Section>();

        static SectionCollection()
        {
            List<SectionConfiguration> configs = ConfigurationService.GetConfigs();

            foreach (SectionConfiguration config in configs)
            {
                _cachedSections.Add(config.SectionName.ToUpper(), new Section(config.SectionName, config.SectionColor, config.SectionQuestionTwitterId, config.SectionResponsesTwitterHashTag));
            }
        }

        public static Section Section(string sectionName)
        {
            return _cachedSections[sectionName.ToUpper()];
        }

        public static bool ContainsSection(string sectionName)
        {
            return _cachedSections.ContainsKey(sectionName.ToUpper());
        }

        public static List<SectionSummaryViewData> GetSummary()
        {
            return (from s in _cachedSections.Values
                    orderby s.SectionName
                    select new SectionSummaryViewData
                    {
                        SectionName = s.SectionName,
                        SectionColor = s.SectionColor,
                        SectionQuestion = s.SectionQuestionTwitterfied
                    }).ToList();
        }
    }
}
