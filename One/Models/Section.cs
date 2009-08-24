using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dimebrain.TweetSharp.Fluent;
using Dimebrain.TweetSharp.Model;
using Dimebrain.TweetSharp.Extensions;
using One.ViewData;
using One.Helpers;

namespace One.Models
{
    public class Section
    {
        private const int ITEMS_PER_PAGE = 10;

        private string _sectionName;
        private string _sectionColor;
        private string _sectionQuestionTwitterId;
        private string _sectionResponsesTwitterHashTag;

        private DateTime _nextUpdateDateTime = DateTime.Now;

        private string _cachedQuestion = string.Empty;
        private string _cachedQuestionTwitterfied = string.Empty;
        private long _cachedQuestionId;
        private SortedDictionary<int, ResponsePageViewData> _cachedResponsePages = new SortedDictionary<int, ResponsePageViewData>();

        public Section(string sectionName, string sectionColor, string sectionQuestionTwitterId, string sectionResponsesTwitterHashTag)
        {
            _sectionName = sectionName;
            _sectionColor = sectionColor;
            _sectionQuestionTwitterId = sectionQuestionTwitterId;
            _sectionResponsesTwitterHashTag = sectionResponsesTwitterHashTag;
        }

        public string SectionName
        {
            get { return _sectionName; }
        }

        public string SectionColor
        {
            get { return _sectionColor; }
        }

        public string SectionQuestionTwitterfied
        {
            get
            {
                if (string.IsNullOrEmpty(_cachedQuestion))
                    GetQuestionFromTwitter();

                return _cachedQuestionTwitterfied;
            }
        }

        public ResponsePageViewData GetResponsePageViewData(int page)
        {
            if (DateTime.Now >= _nextUpdateDateTime)
            {
                _cachedResponsePages.Clear();
                _nextUpdateDateTime = DateTime.Now.AddMinutes(1);
            }

            if (!_cachedResponsePages.ContainsKey(page))
            {
                ResponsePageViewData respPage = new ResponsePageViewData();

                respPage.SectionName = _sectionName;
                respPage.SectionColor = _sectionColor;
                respPage.Question = GetQuestionFromTwitter();
                respPage.QuestionHtmlEncoded = HttpUtility.HtmlEncode(respPage.Question);
                respPage.QuestionTwitterfied = _cachedQuestionTwitterfied;
                respPage.SectionResponsesTwitterHashTag = _sectionResponsesTwitterHashTag;

                TwitterSearchResult twitterSearchResult = GetResponsesFromTwitter(page);
                respPage.CurrentPageHtml = TwitterHelper.TwitterCurrentPage(twitterSearchResult);
                respPage.PreviousPageHtml = TwitterHelper.TwitterPrevPageLink(_sectionName, twitterSearchResult);
                respPage.NextPageHtml = TwitterHelper.TwitterNextPageLink(_sectionName, twitterSearchResult);
                respPage.Responses = new List<ResponseViewData>();

                foreach (TwitterSearchStatus status in twitterSearchResult.Statuses)
                {
                    respPage.Responses.Add(new ResponseViewData
                    {
                        AvatarHtml = TwitterHelper.TwitterAvatar(status),
                        MessageHtml = TwitterHelper.TwitterMessage(status),
                        RelativeTimeHtml = TwitterHelper.TwitterRelativeTime(status),
                        SourceHtml = TwitterHelper.TwitterSource(status),
                        ReplyLinkHtml = TwitterHelper.TwitterReplyLink(status),
                        ViewTweetLinkHtml = TwitterHelper.TwitterViewTweetLink(status),
                    });
                }

                if (DateTime.Now.Hour >= 22)
                    respPage.QuestionRefreshedDate = DateTime.Today;
                else
                    respPage.QuestionRefreshedDate = DateTime.Today.AddDays(-1);

                _cachedResponsePages[page] = respPage;                
            }

            return _cachedResponsePages[page];
        }

        private string GetQuestionFromTwitter()
        {
            // Get the public timeline
            var twitter = FluentTwitter.CreateRequest()
                .Statuses()
                .OnUserTimeline()
                .For(_sectionQuestionTwitterId)
                .Take(1)
                .AsJson();

            // Sequential call for data and Convert response to data classes 
            var request = twitter.Request();

            var statuses = request.AsStatuses();

            if (statuses == null)
            {
                //Do some error handling
            }
            else
            {
                _cachedQuestionId = statuses.First().Id;
                _cachedQuestion = statuses.First().Text;
                _cachedQuestionTwitterfied = TwitterHelper.TwitterfyText(_cachedQuestion);

            }

            return _cachedQuestion;
        }

        private TwitterSearchResult GetResponsesFromTwitter(int page)
        {
            var twitter = FluentTwitter.CreateRequest()
                    .Search()
                    .Query()
                    .ContainingHashTag(_sectionResponsesTwitterHashTag)
                    .Since(_cachedQuestionId)
                    .Take(ITEMS_PER_PAGE)
                    .Skip(page)
                    .AsJson();

            var request = twitter.Request();

            var searchResult = request.AsSearchResult();

            if (searchResult == null)
            {
                //Do some error handling
                return null;
            }
            else
            {
                return searchResult;
            }
        }
    }
}
