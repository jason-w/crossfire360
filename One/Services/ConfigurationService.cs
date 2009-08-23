using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using One.Models;

namespace One.Services
{
    public static class ConfigurationService
    {
        public static List<SectionConfiguration> GetConfigs()
        {
            return new List<SectionConfiguration>
            {
                new SectionConfiguration{
                     SectionName= "Politics",
                     SectionColor = "C3D9FF",
                     SectionQuestionTwitterId = "andersoncooper",
                     SectionResponsesTwitterHashTag = "politics"
                }, 
                new SectionConfiguration{
                     SectionName= "Sports",
                     SectionColor = "CDEB8B",
                     SectionQuestionTwitterId = "THE_REAL_SHAQ",
                     SectionResponsesTwitterHashTag = "sports"
                },
                new SectionConfiguration{
                     SectionName= "Technology",
                     SectionColor = "FFFF88",
                     SectionQuestionTwitterId = "gigaom",
                     SectionResponsesTwitterHashTag = "apple"
                }
            };
        }
    }
}
