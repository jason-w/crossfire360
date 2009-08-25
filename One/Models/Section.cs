using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Text;
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
        private const int TWIITER_CONNECT_TIMEOUT = 750; // in milliseconds

        private string _sectionName;        
        private string _sectionColor;
        private string _sectionQuestionTwitterId;
        private string _sectionQuestionTwitterPassword;
        private string _sectionResponsesTwitterHashTag;

        private DateTime _nextRawQuestionUpdateDateTime = DateTime.Now.AddDays(-1);
        private SortedDictionary<int, DateTime> _nextRawResponsesUpdateDateTime = new SortedDictionary<int, DateTime>();

        private string _cachedQuestion = string.Empty;
        private string _cachedQuestionSEOFriendly = string.Empty;
        private string _cachedQuestionHtmlEncoded = string.Empty;
        private string _cachedQuestionTwitterfied = string.Empty;
        private long _cachedQuestionId;
        private SortedDictionary<int, ResponsePageViewData> _cachedResponsePages = new SortedDictionary<int, ResponsePageViewData>();

        private TwitterStatus _cachedRawQuestion = new TwitterStatus();
        private SortedDictionary<int, TwitterSearchResult> _cachedRawResponses = new SortedDictionary<int, TwitterSearchResult>();
        private DateTime _lastSuccessfulRawQuestionGet = DateTime.Now;
        private SortedDictionary<int, DateTime> _lastSuccessfulRawResponsesGet = new SortedDictionary<int, DateTime>();
        private bool _isLastRawQuestionGetSuccessful = false;
        private SortedDictionary<int, bool> _isLastRawResponsesGetSuccessful = new SortedDictionary<int, bool>();
        private bool _isRawQuestionSameAsBefore = false;

        public Section(string sectionName, string sectionColor, string sectionQuestionTwitterId, string sectionQuestionTwitterPassword, string sectionResponsesTwitterHashTag)
        {
            _sectionName = sectionName;
            _sectionColor = sectionColor;
            _sectionQuestionTwitterId = sectionQuestionTwitterId;
            _sectionQuestionTwitterPassword = sectionQuestionTwitterPassword;
            _sectionResponsesTwitterHashTag = sectionResponsesTwitterHashTag;

            _nextRawQuestionUpdateDateTime = DateTime.Now.AddDays(-1);
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
                    GetResponsePageViewData(1);

                return _cachedQuestionTwitterfied;
            }
        }

        public string SectionQuestionSEOFriendly
        {
            get
            {
                if (string.IsNullOrEmpty(_cachedQuestion))
                    GetResponsePageViewData(1);

                return _cachedQuestionSEOFriendly;
            }
        }

        public ResponsePageViewData GetResponsePageViewData(int page)
        {
            if (DateTime.Now >= _nextRawQuestionUpdateDateTime)
            {
                CallWithTimeout(GetRawQuestion, TWIITER_CONNECT_TIMEOUT);
                if (_isLastRawQuestionGetSuccessful && !_isRawQuestionSameAsBefore)
                {
                    _cachedResponsePages.Clear();
                    _cachedRawResponses.Clear();
                    _lastSuccessfulRawResponsesGet.Clear();
                    _nextRawResponsesUpdateDateTime.Clear();
                    _cachedQuestion = _cachedRawQuestion.Text;
                    _cachedQuestionHtmlEncoded = HttpUtility.HtmlEncode(_cachedQuestion);
                    _cachedQuestionTwitterfied = TwitterHelper.TwitterfyText(_cachedQuestion);
                    _cachedQuestionSEOFriendly = ToFriendlyUrl(_cachedQuestion);
                    _cachedQuestionId = _cachedRawQuestion.Id;
                }
            }

            if (!_nextRawResponsesUpdateDateTime.ContainsKey(page) || DateTime.Now >= _nextRawResponsesUpdateDateTime[page])
            {
                CallWithTimeout(GetRawResponses, page, TWIITER_CONNECT_TIMEOUT);
            }

            if (!_cachedResponsePages.ContainsKey(page) && _cachedRawResponses.ContainsKey(page))
            {
                ResponsePageViewData respPage = new ResponsePageViewData();
                TwitterSearchResult twitterSearchResult = _cachedRawResponses[page];

                respPage.State = ResponsePageViewDataState.UpdateToDateData;
                respPage.SectionName = _sectionName;
                respPage.SectionColor = _sectionColor;
                respPage.Question = _cachedQuestion;
                respPage.QuestionSEOFriendly = _cachedQuestionSEOFriendly;
                respPage.QuestionHtmlEncoded = _cachedQuestionHtmlEncoded;
                respPage.QuestionTwitterfied = _cachedQuestionTwitterfied;
                respPage.SectionResponsesTwitterHashTag = _sectionResponsesTwitterHashTag;

                respPage.CurrentPageHtml = TwitterHelper.TwitterCurrentPage(twitterSearchResult);
                respPage.PreviousPageHtml = TwitterHelper.TwitterPrevPageLink(_sectionName, twitterSearchResult, _cachedQuestionSEOFriendly);
                respPage.NextPageHtml = TwitterHelper.TwitterNextPageLink(_sectionName, twitterSearchResult, _cachedQuestionSEOFriendly);
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

                if (DateTime.Now.Hour >= 8)
                    respPage.QuestionRefreshedDate = DateTime.Today;
                else
                    respPage.QuestionRefreshedDate = DateTime.Today.AddDays(-1);

                respPage.LastUpdatedDateTime = _nextRawResponsesUpdateDateTime[page];

                _cachedResponsePages[page] = respPage;

                return respPage;
            }
            else if (!_cachedResponsePages.ContainsKey(page) && !_cachedRawResponses.ContainsKey(page))
            {
                ResponsePageViewData respPage = new ResponsePageViewData();

                respPage.State = ResponsePageViewDataState.DataUnavailable;
                respPage.SectionName = _sectionName;
                respPage.SectionColor = _sectionColor;
                respPage.Question = _cachedQuestion;
                respPage.QuestionHtmlEncoded = _cachedQuestionHtmlEncoded;
                respPage.QuestionTwitterfied = _cachedQuestionTwitterfied;
                respPage.SectionResponsesTwitterHashTag = _sectionResponsesTwitterHashTag;
                respPage.Responses = new List<ResponseViewData>();

                return respPage;
            }
            else if (_cachedResponsePages.ContainsKey(page) && DateTime.Now <= _nextRawResponsesUpdateDateTime[page])
            {
                ResponsePageViewData respPage = _cachedResponsePages[page];
                respPage.State = ResponsePageViewDataState.UpdateToDateData;
                return respPage;
            }
            

            ResponsePageViewData outdatedRespPage = _cachedResponsePages[page];
            outdatedRespPage.State = ResponsePageViewDataState.OutdatedData;
            return outdatedRespPage;
            
        }

        private void GetRawQuestion()
        {
            _isLastRawQuestionGetSuccessful = false;
            _isRawQuestionSameAsBefore = true;

            var twitter = FluentTwitter.CreateRequest()
                .AuthenticateAs(_sectionQuestionTwitterId, _sectionQuestionTwitterPassword)
                .Statuses()
                .OnUserTimeline()
                .For(_sectionQuestionTwitterId)
                .Take(1)
                .AsJson();

            try
            {
                var request = twitter.Request();

                var statuses = request.AsStatuses();

                if (statuses != null && statuses.Count() > 0)
                {
                    var newRawQustion = statuses.First();

                    _isRawQuestionSameAsBefore = newRawQustion.Text.Equals(_cachedRawQuestion.Text);

                    _cachedRawQuestion = newRawQustion;
                    _isLastRawQuestionGetSuccessful = true;
                    _lastSuccessfulRawQuestionGet = DateTime.Now;
                    _nextRawQuestionUpdateDateTime = DateTime.Now.AddSeconds(new Random().Next(45,75));
                }
            }
            catch
            {
                _isLastRawQuestionGetSuccessful = false;
            }
        }

        private void GetRawResponses(int page)
        {
            _isLastRawResponsesGetSuccessful[page] = false;

            var twitter = FluentTwitter.CreateRequest()
                    .Search()
                    .Query()
                    .ContainingHashTag(_sectionResponsesTwitterHashTag)
                    .Since(_cachedQuestionId)
                    .Take(ITEMS_PER_PAGE)
                    .Skip(page)
                    .AsJson();

            try
            {
                var request = twitter.Request();

                var searchResult = request.AsSearchResult();

                if (searchResult != null)
                {
                    _cachedRawResponses[page] = searchResult;
                    _isLastRawResponsesGetSuccessful[page] = true;
                    _lastSuccessfulRawResponsesGet[page] = DateTime.Now;
                    _nextRawResponsesUpdateDateTime[page] = DateTime.Now.AddSeconds(new Random().Next(45, 75));
                    _cachedResponsePages.Remove(page);
                }
            }
            catch
            {
                _isLastRawResponsesGetSuccessful[page] = false;
            }
        }

        private static string ToFriendlyUrl(string urlToEncode)
        {
            urlToEncode = (urlToEncode ?? "").Trim().ToLower();

            StringBuilder url = new StringBuilder();

            foreach (char ch in urlToEncode)
            {
                switch (ch)
                {
                    case ' ':
                        url.Append('-');
                        break;
                    case '&':
                        url.Append("and");
                        break;
                    case '\'':
                        break;
                    default:
                        if ((ch >= '0' && ch <= '9') ||
                            (ch >= 'a' && ch <= 'z'))
                        {
                            url.Append(ch);
                        }
                        else
                        {
                            url.Append('-');
                        }
                        break;
                }
            }

            return url.ToString();
        } 

        static void CallWithTimeout(Action action, int timeoutMilliseconds)
        {
            Thread threadToKill = null;
            Action wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                action();
            };

            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                if (threadToKill != null)
                    threadToKill.Abort();
                //throw new TimeoutException();
            }
        }

        static void CallWithTimeout(Action<int> action, int page, int timeoutMilliseconds)
        {
            Thread threadToKill = null;
            Action wrappedAction = () =>
            {
                threadToKill = Thread.CurrentThread;
                action(page);
            };

            IAsyncResult result = wrappedAction.BeginInvoke(null, null);
            if (result.AsyncWaitHandle.WaitOne(timeoutMilliseconds))
            {
                wrappedAction.EndInvoke(result);
            }
            else
            {
                if (threadToKill != null)
                    threadToKill.Abort();
                //throw new TimeoutException();
            }
        }


    }
}
