<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<One.ViewData.ResponsePageViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Crossfire 360 - <%=Model.Question%></title>
    <link href="../../Content/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div id="main">
        <div id="mainContent">
            <div id="header">
                <div id="slogan">
                    <h2>One Day. One Question. 360&deg; Perspective.</h2>
                </div>
                <div id="suggest">
                    <a href="mailto:suggestion@crossfire360.com">Suggestion a question</a>
                </div>
            </div>
            <div id="sidebar">
                <div class="module">
                    <div class="nav">
                        <a href="/">Home</a>
                    </div>
                </div>            
                <%foreach(SectionSummaryViewData summary in Model.SectionSummary){ %>
                <div class="module" style="background-color: #<%=summary.SectionColor%>;">
                    <div class="nav">
                        <a href="/<%=summary.SectionName%>"><%=summary.SectionName %></a>
                    </div>                        
                </div>
                <%} %>
                <div class="module">
                    <p>To particpate in today's crossfire, tweet your response with hashtag <span style="background-color: #<%=Model.SectionColor%>;">#<%=Model.SectionResponsesTwitterHashTag%></span></p>
                <div class="module list">
                    <h3>
                        <b>Share</b>
                        today's question:
                    </h3>
                    <div id="share">
                        <ul>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Mixx')" href="http://www.mixx.com/submit/story?page_url=www.crossfire360.com">Mixx</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Digg')" href="http://digg.com/submit?phase=2&url=www.crossfire360.com&title=<%=Model.QuestionHtmlEncoded%>&bodytext=">Digg</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Facebook')" href="http://www.facebook.com/share.php?u=www.crossfire360.com&t=<%=Model.QuestionHtmlEncoded%>">Facebook</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Delicious')" href="http://del.icio.us/post?v=4&noui&jump=close&url=www.crossfire360.com&title=<%=Model.QuestionHtmlEncoded%>">delicious</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Reddit')" href="http://reddit.com/submit?url=www.crossfire360.com&title=<%=Model.QuestionHtmlEncoded%>">reddit</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/StumbleUpon')" href="http://www.stumbleupon.com/submit?url=www.crossfire360.com&title=<%=Model.QuestionHtmlEncoded%>">StumbleUpon</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/MySpace')" href="http://www.myspace.com/Modules/PostTo/Pages/?t=<%=Model.QuestionHtmlEncoded%>&c=&u=www.crossfire360.com">MySpace</a></li>
                            <li><a onclick="pageTracker._trackPageview('/exit/to/Twitter')" href="http://twitter.com/?status=RT%20@cf360%20<%=Model.QuestionHtmlEncoded%>">Twitter</a></li>
                        </ul>
                    </div>
                </div>
                <div class="module">
                    <p>Want to help? We sure can use some design help!  Email us at <a href="mailto:help@crossfire360.com">help@crossfire360.com</a> if working for free is your thing.</p>
                </div>
            </div>
            <div id="content">
                <div id="topshare">
                    <div id="tweetmeme">
                        <script type="text/javascript">
                            tweetmeme_source = 'cf360';
                        </script>
                        <script type="text/javascript" src="http://tweetmeme.com/i/scripts/button.js"></script>
                    </div>
                    <div id="digg">
                        <script src="http://digg.com/tools/diggthis.js" type="text/javascript"></script> 
                    </div>
                </div>
                <div id="contentheader">
                    <h2><b>Today's <%=Model.SectionName%> Question:</b></h2>
                    <div id="question" style="background-color: #<%=Model.SectionColor%>;">
                            <h2><%=Model.QuestionTwitterfied%></h2>
                            <h3>This question was posted on <%=Model.QuestionRefreshedDate.ToShortDateString()%> 10PM PT and it will change again on <%=Model.QuestionRefreshedDate.AddDays(1).ToShortDateString()%> 10PM PT.</h3>    
                    </div>
                    <h2><b>Responses (<img src="../../Content/twitter-icon.jpg" /> <a href="http://twitter.com/?status=%23cf360">tweet yours</a>):</b></h2>
                </div>                
                <%if (Model.Responses.Count == 0) {%>
                <div id="noresponse">
                    <h2>Hurry, be the first!</h2>                    
                    <div id="noresponseblank">&nbsp;</div>
                </div>
                <% }else{ %>
                <ul>
                    <%foreach (ResponseViewData response in Model.Responses)
                      { %>
                    <li class="result">
                        <div class="avatar">
                           <%=response.AvatarHtml%>
                        </div>
                        <div class="msg">
                           <%=response.MessageHtml%>
                        </div>
                        <div class="info">
                            <%=response.RelativeTimeHtml%> <span class="source">from <%=response.SourceHtml%> </span>� <%=response.ReplyLinkHtml%> � <%=response.ViewTweetLinkHtml%>
                        </div>
                        <p class="clearleft"></p>
                    </li>
                    <%} %>
                
                <% } %>
                </ul>
                <div id="pager-bottom" class="paginator">
                    <%=Model.PreviousPageHtml%>  
                    <%=Model.CurrentPageHtml%>          
                    <%=Model.NextPageHtml%>     
                </div>
            </div>
            <div id="footer">
                <a href="/about/">About</a> | <a href="/about/terms-of-service">Terms of Service</a> | <a href="/about/privacy-policy">Privacy Policy</a>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>
    <script type="text/javascript">
    try {
        var pageTracker = _gat._getTracker("UA-10327169-1");
        pageTracker._trackPageview();
    } catch (err) { }</script>
</body>
</html>