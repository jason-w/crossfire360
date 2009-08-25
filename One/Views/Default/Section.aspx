<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<One.ViewData.ResponsePageViewData>" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PageTitle" runat="server">
<%=Model.Question%> - Crossfire 360
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Sidebar" runat="server">
<div class="module">
    <p>To particpate in today's crossfire, tweet your response with hashtag <span style="background-color: #<%=Model.SectionColor%>;">#<%=Model.SectionResponsesTwitterHashTag%></span></p>    <p>Follow us on <a href="http://www.twitter.com/cf360">@cf360</a></p></div>
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                <h3>This question was posted on <%=Model.QuestionRefreshedDate.ToShortDateString()%> 8AM PT and it will change again on <%=Model.QuestionRefreshedDate.AddDays(1).ToShortDateString()%> 8AM PT.</h3>    
        </div>
        <h2><b>Responses (<img src="../../Content/twitter-icon.jpg" /> <a href="http://twitter.com/?status=%23<%=Model.SectionResponsesTwitterHashTag%>">tweet yours</a>):</b></h2>
    </div>    
    <%if (Model.State != ResponsePageViewDataState.UpdateToDateData) { %>
    <div id="outofdate">
        Yikes!  Looks like Twitter is taking a nap right now.  We'll bring you the latest responses as soon as Twitter wakes up.  The responses you see blow are at least <%= ((TimeSpan) (DateTime.Now - Model.LastUpdatedDateTime)).Seconds%> seconds old.
    </div>            
    <% } %>
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
                <%=response.RelativeTimeHtml%> <span class="source">from <%=response.SourceHtml%> </span>· <%=response.ReplyLinkHtml%> · <%=response.ViewTweetLinkHtml%>
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
</asp:Content>