<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<One.ViewData.AboutViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Crossfire 360 - Privacy Policy</title>
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
                    <h2>Privacy Policy</h2>

                    <p>The short version is that we will never, ever sell or share your information. But our lawyers would only let us write the &quot;nice&quot; version if we made it long enough to look official, so to spare you their not-so-sprightly legalese, we must comply.</p>

                    <h3>Privacy Policy Updates</h3>

                    <p>Because things change so quickly these days, we may have to update our privacy policy from time to time. We'll post these updates to Crossfire 360 and update via <a href="http://twitter.com/cf360">@cf360</a> any changes.</p>

                    <h3>How and Why We Collect and Use Information</h3>

                    <p>You don't have to give us any of your personal information to use Crossfire 360. But we might ask you to provide feedback, engage in contests, discussions, message boards, or when you register as a member of the Crossfire 360. So we may collect this information.</p>

                    <p>And yes, we may also throw you some sponsored stories and even some adverts (shock horror) - but we do have to pay ourselves someday.</p>

                    <h3>Children's Privacy</h3>

                    <p>
                    Kids are adorable. So are puppies. We don't think Crossfire 360 is appropriate for either. We do not knowingly collect or save any information from children under the age of 13.</p>

                    <h3>Cookies</h3>

                    <p>We may use cookies to improve your Crossfire 360 experience. These cookies do not generally allow us to personally identify a specific user.</p>

                    <h3>Disclosure</h3>

                    <p>We may need to share your information with any of the companies that help provide the Crossfire 360 service; we'll make them to sign a confidentiality agreement, too. If, of course, we're required by law or government regulation, or of the company changes hands, we'll have to fork it over. But basically, as we said before: We're not going to sell or share your personal information.</p>

                    <h3>Links to Third Party Sites</h3>

                    <p>If you follow any of the links you find on Crossfire 360, our privacy policy stops at the door. Whenever you go to another site, you have to abide by their terms of use and are subject to their privacy policies.</p>

                    <p>If you have any questions about our Privacy Policy, send us via a email <a href="mailto:info@crossfire360.com">info@crossfire360.com</a></p>
                
                    <h4>(These privacy polocy were inspired, with [pending] permission, by Tweetmeme.com.)</h4>
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

