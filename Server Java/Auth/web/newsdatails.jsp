<%-- 
    Document   : newsdatails
    Created on : Apr 15, 2021, 1:07:24 PM
    Author     : artem
--%>

<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    orm.News theNews = (orm.News) request.getAttribute("theNews");
    orm.User theNewsAuthor = (orm.User) request.getAttribute("theNewsAuthor");
    ArrayList<orm.NewsComment> comments = (ArrayList<orm.NewsComment>) request.getAttribute("theNewsComments");
    orm.User authUser = (orm.User) request.getAttribute("authUser");
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Новость</title>
        <link 
            rel='stylesheet' 
            href='<%= request.getContextPath()%>/css/newsdtl.css' />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    </head>
    <body>
        <div class="wrap-dtl">
            <img src='<%= request.getContextPath()
                    + "/newsavatars/"
                    + theNews.getAvatar()%>' />

            <h1><%= theNews.getTitle()%> </h1>
            <h2><%= theNews.getMoment()%></h2>
            <h3>Автор: 
                <i><%= theNewsAuthor.getNik()%></i>
            </h3>
            <div class='clear'></div>
            <p>
                <%= theNews.getContentFull()%>
            </p>

            <section>
                <h2>Комментарии</h2>
                <b><%= (authUser == null) ? "Аноним" : authUser.getNik()%></b>:<br/>
                <div class="form-group">
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" > </textarea>
                </div>
                <button class="btn btn-light" onclick='addComment()'>Добавить</button>
                <br/>
            </section>
        </div>
        <% if (comments != null) {
                for (orm.NewsComment comment : comments) {%>
        <div class="container alert alert-primary " role="alert">
            <div class="row">
                <div class="col" ><%=comment.getAuthorNik() != null ? comment.getAuthorNik() : "Ananumus"%></div>
                <div class="col"><%= comment.getMoment()%></div>
            </div>
            <div class="row">
                <div class="col" ><%= comment.getCommint()%></div>
            </div>
            <div class="row">
                <div class="col-md-4 offset-md-10"><button class="btn btn-outline-dark">Answer</button></div>
            </div>

        </div>
        <% }
            }%>

        <script>
            function addComment() {
                // id news
                const idNews = <%= theNews.getId()%>;

                // id author
                const idAuthor = <%= (authUser == null) ? 0 : authUser.getId()%>;

                // comment text

                const ta = document.querySelector('section textarea');
                if (!ta) {
                    throw "textarea not found";
                }
                const txt = ta.value;

                if (txt.length < 3) {
                    alert("Comment most small");
                    return;
                }
                fetch('<%= request.getContextPath() + "/news"%>', {
                    method: "POST",
                    body: `idNews=\${idNews}&idAuthor=\${idAuthor}&txt=\${txt}`,
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                        .then(r => r.text())
                        .then(res => {
                            if (res == "1") {
                                location = location;
                            } else {
                                alert("Server bug" + res);
                            }

                        });
                    
                //console.log( idNews + " " + idAuthor + " " + txt);

            }
        </script>
    </body>
</html>
