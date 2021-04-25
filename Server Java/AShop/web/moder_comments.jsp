<%-- 
    Document   : moder_comments
    Created on : Apr 22, 2021, 2:00:40 AM
    Author     : artem
--%>
<%@page import="java.util.ArrayList"%>
<%
    ArrayList<orm.ProductComment> comments = (ArrayList<orm.ProductComment>) request.getAttribute("commentsList");
%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    </head>
    <body>
        <h1 style="text-align: center">Moder comments    <a href='<%= request.getContextPath() + "/shop"%>' ><button class="btn btn-danger">To Shop</button></a></h1>

        <% if (comments != null) {
                for (orm.ProductComment comment : comments) {%>

        <div class="container alert alert-<%= comment.getBlocked() == 0 ? "primary" : "danger"%>" role="alert">

            <div class="row"> 
                <div><button onClick="toggleComment(' <%=comment.getId()%> ')" class="btn btn-light"><%= comment.getBlocked() == 0 ? "заблокировать" : "разблоеировать"%></button></div>
                <div class="col" ><%=comment.getAuthorNik() != null ? comment.getAuthorNik() : "Ananumus"%></div>
                <div class="col"><%= comment.getMoment()%></div>
            </div>
            <div class="row">
                <div class="col" ><%= comment.getCommint()%></div>
            </div>
            <div class="row">
                <div class="col" >News ID <%= comment.getIdProduct() %></div>
            </div>
            <div class="row">
                <div class="col" >Blocked <%= comment.getBlocked()%></div>
            </div>
        </div>
        <% }
            }%>
   
        <script>
            function toggleComment(cid) {

                console.log(cid);
                const url = '<%= request.getContextPath()%>/moder/';
                fetch(url, {
                    method: "POST",
                    body: "command=toggleComment&cid=" + cid,
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
