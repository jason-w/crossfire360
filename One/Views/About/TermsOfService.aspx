<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<One.ViewData.AboutViewData>" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Crossfire 360 - Terms of Service</title>
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
                    <h2>Terms of Service</h2>
                    <h3>Crossfire 360 General Terms of Use</h3>
                    <p>
                        So nice of you to come visit. Well you won't find a boring set of legal ease because
                        we don't want to pay a lawyer.</p>
                    <p>
                        By using the Crossfire 360 site, you are agreeing to play by our rules, which will govern
                        your use of Crossfire 360 on this lovely internet.</p>
                    <p>
                        Before we start, we must mention that we get to change these rules whenever we like
                        (good huh?). But don't worry we'll let you know so you can decide if you want to
                        keep playing.</p>
                    <h3>General Use Restrictions</h3>
                    <p>
                        All of the content you find on Crossfire 360 is user-generated, we take every status you
                        post on Twitter and post them on our site. This includes your references to
                        blog posts, pictures, videos and pretty much anything else you find on the internet.
                        Anything else that does not come via twitter is owned by Crossfire 360 so please
                        do not take it unless you ask us nicely first.</p>
                    <h3>Third Party Content</h3>
                    <p>
                        We have partners and other suppliers who provide us with their content. You can
                        use it, but again, only for personal use and with no changes, unless you get permission
                        directly from that partner. And no, we can't just get permission for you. That would
                        fall under &quot;not our job.&quot; We also can't take any responsibility for the
                        truthfulness of any claims, warranties or fitness for any particular purpose, whether
                        stated outright or implied.</p>
                    <h3>Links to Third Party Sites</h3>
                    <p>
                        Just because links shows up on Crossfire 360 doesn't mean that we're endorsing them
                        or any of the content or other links you may find when you get there.</p>
                    <h3>Unauthorized Activity</h3>
                    <p>
                        Misbehave and you're the one who will be in trouble, not us. When you agree to play
                        by our rules, you agree that no one employed by or in any way related to Crossfire 360
                        will be held accountable for your actions, legally or financially. And if we have
                        to protect ourselves in court because of your actions, we will stick you with the
                        bill.</p>
                    <h3>Copyright and Trademark Infringement</h3>
                    <p>
                        We respect the intellectual property rights of others and we ask that our users
                        do the same. If you are a copyright holder and believe that your work has been borrowed/stolen,
                        altered, illegally copied or misused in any other way, please let us know. We'll
                        need some supporting documentation, a list of which you'll find <a href="/about/copyright/">
                            here</a>.
                    </p>
                    <h3>Disclaimer of Warranties</h3>
                    <p>
                        As much as we'd love to, we just can't vet every single post on Crossfire 360.
                        And even some of our stuff might have the occasional inaccuracy or typo. We are
                        not responsible for any of these errors, either on Crossfire 360 or a third-party site.
                        We offer Crossfire 360 to you on an &quot;as-is&quot; basis.</p>
                    <h3>Limitation of Liability</h3>
                    <p>
                        If you misbehave while you're on Crossfire 360 - download stuff you shouldn't, make
                        illegal copies, that sort of thing-we are not responsible; we warned you, but you'll
                        have to take your lumps.
                    </p>
                    <h4>(These terms of service were inspired, with [pending] permission, by Tweetmeme.com.)</h4>
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
