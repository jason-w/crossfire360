﻿<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<One.ViewData.DefaultViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Crossfire 360</title>
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
            </div>
            <!--
            <div id="content">
                <p>Welcome to Crossfire 360. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec vel sem magna. Praesent eget volutpat metus. Suspendisse vel enim ut tortor iaculis fringilla. Nunc congue, urna eget ultricies fermentum, lacus augue fringilla leo, vel vulputate urna tortor sed dui. Phasellus hendrerit sollicitudin velit ac hendrerit. Aenean rhoncus condimentum urna, a hendrerit tortor vehicula eu. Curabitur eget augue mi.</p>
            </div>
            -->
                <%foreach(SectionSummaryViewData summary in Model.SectionSummary){ %>
            <div id="content">
                    <div class="summary" style="background-color:#<%=summary.SectionColor%>;">
                        <%=summary.SectionName %>: <%=summary.SectionQuestion %>
                    </div>
                    <div class="recent">Most recent response: (<a href="/<%=summary.SectionName%>">view the rest</a>)</div>
                    <ul>
                    <%if (summary.Responses.Count == 0) {%>
                    <div id="noresponse">
                        <h2>Hurry, be the first!</h2>
                    </div>
                    <% }else{ %>
                    
                        <%foreach (ResponseViewData response in summary.Responses)
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
            </div>
                <%} %>
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
