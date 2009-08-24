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
                     SectionQuestionTwitterId = "cf360_politics",
                     SectionQuestionTwitterPassword = "4thecr0ssfire",
                     SectionResponsesTwitterHashTag = "cf360p"
                }, 
                new SectionConfiguration{
                     SectionName= "Sports",
                     SectionColor = "CDEB8B",
                     SectionQuestionTwitterId = "cf360_sports",
                     SectionQuestionTwitterPassword = "4thecr0ssfire",
                     SectionResponsesTwitterHashTag = "cf360s"
                },
                new SectionConfiguration{
                     SectionName= "Technology",
                     SectionColor = "FFFF88",
                     SectionQuestionTwitterId = "cf360_tech",
                     SectionQuestionTwitterPassword = "4thecr0ssfire",
                     SectionResponsesTwitterHashTag = "cf360t"
                }
            };
        }
    }
}
