using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Util;
using System.Text.RegularExpressions;
using Dimebrain.TweetSharp.Model;
using Dimebrain.TweetSharp.Extensions;

namespace One.Helpers
{
    public static class HtmlExtensions 
    {
        const string ScreenNamePattern = @"@([A-Za-z0-9\-_&;]+)";
        const string HashTagPattern = @"#([A-Za-z0-9\-_&;]+)";
        const string HyperLinkPattern = @"(http://\S+)\s?";


        public static string TwitterAvatar(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return String.Format("<a href=\"http://twitter.com/{0}\" onclick=\"pageTracker._trackPageview('/exit/to/{0}');\" target=\"_blank\"> <img src=\"{1}\"></a>", status.FromUserScreenName, status.ProfileImageUrl);
        }

        public static string TwitterMessage(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return String.Format("<a href=\"http://twitter.com/{0}\" onclick=\"pageTracker._trackPageview('/exit/to/{0}');\" target=\"_blank\">{0}</a>: <span id=\"msgtxt{1}\" class=\"msgtxt en\">{2}</span>", status.FromUserScreenName, status.Id, FormatTweetText(status.Text));
        }

        public static string TwitterRelativeTime(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return status.CreatedDate.ToRelativeTime(false);
        }

        public static string TwitterSource(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return HttpUtility.HtmlDecode(status.Source);
        }

        public static string TwitterReplyLink(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return String.Format("<a href=\"http://twitter.com/?status=@{0}%20%23cf360%20&amp;in_reply_to_status_id={1}&amp;in_reply_to={0}\" class=\"litnv\" onclick=\"pageTracker._trackPageview('/exit/reply/{0}');\" target=\"_blank\">Reply</a>", status.FromUserScreenName, status.Id);
        }

        public static string TwitterViewTweetLink(this HtmlHelper helper, TwitterSearchStatus status)
        {
            return String.Format("<a href=\"http://twitter.com/{0}/statuses/{1}\" class=\"lit\" onclick=\"pageTracker._trackPageview('/exit/status/{1}');\" target=\"_blank\">View Tweet</a>", status.FromUserScreenName, status.Id);
        }

        public static string TwitterCurrentPage(this HtmlHelper helper, TwitterSearchResult result)
        {
            return String.Format("Page {0}", result.Page);
        }

        public static string TwitterNextPageLink(this HtmlHelper helper, TwitterSearchResult result)
        {
            if (!String.IsNullOrEmpty(result.NextPage))
                return String.Format("» <a href=\"/page/{0}/{1}\" class=\"next\">Older</a>",result.Page+1, result.MaxId);
            else
                return string.Empty;
        }

        public static string TwitterPrevPageLink(this HtmlHelper helper, TwitterSearchResult result)
        {
            if (!String.IsNullOrEmpty(result.PreviousPage))
                return String.Format("<a href=\"/page/{0}/{1}\" class=\"prev\">Newer</a> «", result.Page - 1, result.MaxId);
            else
                return string.Empty;
        }

        public static string TwitterPrettifyText(this HtmlHelper helper, string text)
        {
            return FormatTweetText(text);
        }

        private static string FormatTweetText(string text)
        {
            string result = text;

            if (result.Contains("http://"))
            {
                var links = new List<string>();
                foreach (Match match in Regex.Matches(result, HyperLinkPattern))
                {
                    var url = match.Groups[1].Value;
                    if (!links.Contains(url))
                    {
                        links.Add(url);
                        result = result.Replace(url, String.Format("<a href=\"{0}\">{0}</a>", url));
                    }
                }
            }

            if (result.Contains("@"))
            {
                var names = new List<string>();
                foreach (Match match in Regex.Matches(result, ScreenNamePattern))
                {
                    var screenName = match.Groups[1].Value;
                    if (!names.Contains(screenName))
                    {
                        names.Add(screenName);
                        result = result.Replace("@" + screenName,
                           String.Format("<a href=\"http://twitter.com/{0}\">@{0}</a>", screenName));
                    }
                }
            }

            if (result.Contains("#"))
            {
                var names = new List<string>();
                foreach (Match match in Regex.Matches(result, HashTagPattern))
                {
                    var hashTag = match.Groups[1].Value;
                    if (!names.Contains(hashTag))
                    {
                        names.Add(hashTag);
                        result = result.Replace("#" + hashTag,
                           String.Format("<a href=\"http://twitter.com/search?q={0}\">#{1}</a>",
                           HttpUtility.UrlEncode("#" + hashTag), hashTag));
                    }
                }
            }

            return result;
        }

    }
}
