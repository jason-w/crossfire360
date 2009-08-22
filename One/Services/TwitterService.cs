using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using Dimebrain.TweetSharp.Fluent;
using Dimebrain.TweetSharp.Model;
using Dimebrain.TweetSharp.Extensions;

namespace One.Services
{
    public static class TwitterService
    {
        private const string TWITTER_QUESTION_ID = "cf360q";
        private const string TWITTER_HASHTAG = "cf360";
        static readonly object _questionLock = new object();
        static readonly object _searchLock = new object();
        static readonly object _pagingLock = new object();

        private static long _questionId;

        private static DateTime _nextGetQuestionDateTime = DateTime.Now;
        private static DateTime _nextGetSearchResultDateTime = DateTime.Now;

        private static string _cachedQuestion = string.Empty;
        private static SortedDictionary<int, TwitterSearchResult> _cachedPagedSearchResult = new SortedDictionary<int,TwitterSearchResult>();

        public static long QuestionId
        {
            get { return _questionId; }
        }

        public static DateTime NextGetQuestionDateTime
        {
            get { return _nextGetQuestionDateTime; }
        }

        public static DateTime NextGetSearchResultDateTime
        {
            get { return _nextGetSearchResultDateTime; }
        }

        public static string GetQuestion()
        {
            if (DateTime.Now >= _nextGetQuestionDateTime)
            {
                // Get the public timeline
                var twitter = FluentTwitter.CreateRequest()
                    .Statuses()
                    .OnUserTimeline()
                    .For(TWITTER_QUESTION_ID)
                    .Take(1)
                    .AsJson();

                // Sequential call for data and Convert response to data classes 
                var statuses = twitter.Request().AsStatuses();

                lock (_questionLock)
                {
                    _questionId = statuses.First().Id;
                    _nextGetQuestionDateTime = DateTime.Now.AddMinutes(1);
                    _cachedQuestion = statuses.First().Text;
                }

                return _cachedQuestion;
            }
            else
            {
                return _cachedQuestion;
            }
        }

        public static TwitterSearchResult GetResponses(int page, long maxId)
        {
            if (DateTime.Now >= _nextGetSearchResultDateTime)
            {
                lock (_pagingLock)
                {
                    _cachedPagedSearchResult.Clear();
                    _nextGetSearchResultDateTime = DateTime.Now.AddMinutes(1);
                }
            }                

            if (!_cachedPagedSearchResult.ContainsKey(page))
            {
                var twitter = FluentTwitter.CreateRequest()
                    .Search()
                    .Query()
                    .ContainingHashTag(TWITTER_HASHTAG)
                    .Since(_questionId)
                    .Take(15)
                    .Skip(page)
                    .AsJson();

                lock (_pagingLock)
                {
                    _cachedPagedSearchResult.Add(page, twitter.Request().AsSearchResult());                    
                }

                return _cachedPagedSearchResult[page];
            }
            else
            {
                return _cachedPagedSearchResult[page];
            }
        }

        //public static TwitterSearchResult GetResponses()
        //{
        //    if (DateTime.Now >= _nextGetSearchResultDateTime || !_cachedPagedSearchResult.ContainsKey(1))
        //    {
        //        var twitter = FluentTwitter.CreateRequest()
        //            .Search()
        //            .Query()
        //            .ContainingHashTag(TWITTER_HASHTAG)
        //            .Since(_questionId)
        //            .Take(15)
        //            .AsJson();

        //        lock (_searchLock)
        //        {
        //            _cachedPagedSearchResult.Clear();
        //            _cachedPagedSearchResult.Add(1, twitter.Request().AsSearchResult());
        //            _nextGetSearchResultDateTime = DateTime.Now.AddMinutes(1);
        //        }

        //        return _cachedPagedSearchResult[1];
        //    }
        //    else
        //    {
        //        return _cachedPagedSearchResult[1];
        //    }
        //}
    }
}
