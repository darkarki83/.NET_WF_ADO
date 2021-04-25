<%-- 
    Document   : moder_news
    Created on : Apr 21, 2021, 4:36:03 AM
    Author     : artem
--%>
<%@page import="java.util.ArrayList"%>
<%
    ArrayList<orm.News> news = (ArrayList<orm.News>) request.getAttribute("newsList");

%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Moderator Page</title>
        <link rel="stylesheet" href="css/style.css"/>
        <link rel="stylesheet" href="<%=request.getContextPath()%>/css/news.css"/>
    </head>
    <body>
        <h1>Moderator news</h1>

        <div class="add-news" >
            <label> title : </label> <input type="text" name="news-title" /> <br/>
            <label> contentShort : </label> <textarea name="news-short" ></textarea> <br/>
            <label> contentFull </label> <textarea name="news-full" > </textarea><br/>
            <label> avatar </label> <input type="file" name="news-avatar" /> <br/>
            <button class="btn btn-group" onclick="addNews()">Added</button>
        </div>



        <%for (orm.News onenews : news) {%>
        <div class="news-container" style="<%=onenews.getBlocked() != 0 ? "opacity: 0.5" : ""%> ">
            <%--  block blocked news  --%>
            <label><input onchange="toggleNews(<%=onenews.getId()%>, <%=onenews.getBlocked()%>)" type="checkbox" <%=onenews.getBlocked() != 0 ? "checked" : ""%>/> Blocked </label>
                <% if (onenews.getBlocked() > 0) {%>
            <b> <%=onenews.getBlockedReason()%></b>
            <% } else {%>
            <input name='blocked-reason<%=onenews.getId()%>' />
            <% }%>
            <br/>
            <%--  finish block blocked news  --%>

            <p><img class="img-thumbnail" src="../newsavatars/<%= onenews.getAvatar()%>" /></p>
            <h1 onclick="location.href = '<%=request.getContextPath() + "/news/" + onenews.getId()%>'">
                <%= onenews.getTitle()%></h1>
            <h2><%= onenews.getMoment()%></h2>
            <p><%= onenews.getContentShort()%></p>
        </div>
        <% }%> 

        <script>
            function addNews() {
                const title = document.querySelector('[name="news-title"]');
                const short = document.querySelector('[name="news-short"]');
                const full = document.querySelector('[name="news-full"]');
                const avatar = document.querySelector('[name="news-avatar"]');
                let data = new FormData();

                data.append("command", "addNews");
                data.append("title", title.value);
                data.append("short", short.value);
                data.append("full", full.value);
                data.append("avatar", avatar.files[0]);
                const url = '<%=request.getContextPath()%>/moder/';

                fetch(url, {
                    method: "POST",
                    body: data
                }).then(r => r.text())
                        .then(txt => {
                            if (txt == "success") {
                                location = location;
                            } else {
                                alert(txt);
                            }
                        });
            }

            function toggleNews(nid, blocked) {
                //console.log(nid);
                let reason = "";
                if (blocked == 0) {

                    let reasonInput = document.querySelector(`input[name="blocked-reason\${nid}"]`);
                    if (!reasonInput) {
                        throw "input not found";
                        return false;
                    }
                    reason = reasonInput.value;
                    if (reason == "") {
                        alert("input reason");
                        event.target.cheched = false;
                        event.preventDefault();
                        return false;
                    }
                }

                const url = '<%= request.getContextPath()%>/moder/';
                fetch(url, {
                    method: "POST",
                    body: "command=toggleNews&cid=" + nid + "&reason=" + reason,
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                }).then(r => r.text())
                        .then(txt => {
                            if (txt == "success") {

                                location = location;
                            } else {
                                alert(txt);
                            }
                        });

            }
        </script>
    </body>
</html>
