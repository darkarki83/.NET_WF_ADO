<%-- 
    Document   : index
    Created on : Mar 31, 2021, 12:57:12 AM
    Author      : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%  
    orm.User authUser = (orm.User)request.getAttribute("authUser");
    
    %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
            <link rel="stylesheet" href="css/style.css"/>
    </head>
    <body class="bg-light">
        
        <h1 style="margin: 10px">Hello <%= authUser.getName() %></h1>
        <img  style="width: 200px; margin: 10px" src="avatars/<%= authUser.getAvatar() %>" />
        
        <!--   View reg data + last visit    -->
        <h3 style="margin: 10px">create data : <%= authUser.getRegMoment() %></h3>
        <h3 style="margin: 10px">last in : <%= authUser.getAuthMoment() %></h3>

        <% if(authUser != null) {  %>
        
        <a style="margin: 10px" href="cabmin" ><button class="btn btn-info" style="width: 100px"> Cabin </button></a>
        <a style="margin: 10px" href="?logout=1" ><button class="btn btn-danger" style="width: 100px"> Exit </button></a>
        <% } %>
        
    </body> 
</html>
