<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<One.ViewData.AboutViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Crossfire 360 - Copyright</title>
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
            <div id="content">
                <div id="boring">
    				<h2>Copyright and Trademark Infringements</h2>

                    <h3>Notification:</h3>

                    <p>Crossfire 360 respects the intellectual property rights of others, and we ask you to do the same. Crossfire 360 may, in appropriate circumstances and at our discretion, terminate service and/or access to this Site for users who infringe the intellectual property rights of others. If you believe that your work is the subject of copyright infringement and/or trademark infringement and appears on our Site, please provide Crossfire 360's designated agent the following information:</p>

                    <ul>
                      <li>A physical or electronic signature of a person authorized to act on behalf of the owner of an exclusive right that is allegedly infringed.</li>

                      <li>Identification of the copyrighted and/or trademarked work claimed to have been infringed, or, if multiple works at a single online site are covered by a single notification, a representative list of such works at that site.</li>

                      <li>Identification of the material that is claimed to be infringing or to be the subject of infringing activity and that is to be removed or access to which is to be disabled at the Site, and information reasonably sufficient to permit Crossfire 360 to locate the material.</li>

                      <li>Information reasonably sufficient to permit Crossfire 360 to contact you as the complaining party, such as an address, telephone number, and, if available, an electronic mail address at which you may be contacted.</li>

                      <li>A statement that you have a good faith belief that use of the material in the manner complained of is not authorized by the copyright and/or trademark owner, its agent, or the law.</li>

                      <li>A statement that the information in the notification is accurate, and under penalty of perjury, that you are authorized to act on behalf of the owner of an exclusive right that is allegedly infringed.</li>
                    </ul>

                    <p>Crossfire 360's agent for notice of claims of copyright or trademark infringement on this Site can be reached as follows:</p>

                    <h3>By e-mail:</h3>

                    <p>abuse@crossfire360.com</p>
	                
                    <h4>(These copyright were inspired, with [pending] permission, by Tweetmeme.com.)</h4>
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

