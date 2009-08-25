<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<One.ViewData.DefaultViewData>" %>

<asp:Content ID="PageTitle" ContentPlaceHolderID="PageTitle" runat="server">
Crossfire 360
</asp:Content>

<asp:Content ID="Sidebar" ContentPlaceHolderID="Sidebar" runat="server">
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <%foreach(SectionSummaryViewData summary in Model.SectionSummary){ %>
        <div id="content">
                <div class="summary" style="background-color:#<%=summary.SectionColor%>;">
                    <%=summary.SectionName %>: <%=summary.SectionQuestion %>
                </div>
                <div class="recent">Most recent response: (<a href="/<%=summary.SectionName%>/<%=summary.SectionQuestionSEOFriendly%>">view the rest</a>)</div>                    
                <%if (summary.Responses.Count == 0) {%>
                <div id="noresponse">
                    <h2>Hurry, be the first!</h2>
                </div>
                <% }else{ %>
                <ul>
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
</asp:Content>
