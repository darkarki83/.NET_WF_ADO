<%-- 
    Document   : newsdtl
    Created on : Apr 15, 2021, 1:29:18 AM
    Author     : artem
--%>

<% orm.News onenews = (orm.News) request.getAttribute("theNews");
    orm.User theNewsAuthor = (orm.User) request.getAttribute("theNewsAuthor");

%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Новость</title>
        <link rel="stylesheet" href="<%=request.getContextPath()%>/css/newsdtl.css"/>
    </head>
    <body>
        <div class="wrap-dtl">
            <p><img class="img-thumbnail" src="<%=request.getContextPath()%>/newsavatars/<%= onenews.getAvatar()%>" /></p>
            <h1><%= onenews.getTitle()%></h1>
            <h3><%= onenews.getMoment()%></h3>      

            <h2>Author : <%= theNewsAuthor.getName()%></h2>
            <%--<h2>Author : <%= utilits.UserUtil.getById(onenews.getIdAuthor()).getNik() %></h2>
            --%>
            <div class="clear">
                <p><%= onenews.getContentFull()%></p>
            </div>
            
            <div>
                <label></label>
                <input type="text" name=""  />
            </div>

        </div>
    </body>
</html>
