<%-- 
    Document   : index
    Created on : Mar 31, 2021, 12:57:12 AM
    Author      : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    </head>
    <body class="bg-light">
        
        <h1 style="margin: 10px">Hello <%= request.getAttribute("username") %></h1>
        <img  style="width: 200px; margin: 10px" src="avatars/<%= request.getAttribute("avatar")%>" />
        
        <!--   View reg data + last visit    -->
        <h3 style="margin: 10px">create data : <%= request.getAttribute("regdata") %></h3>
        <h3 style="margin: 10px">last in : <%= request.getAttribute("lastdata") %></h3>

        <% if(request.getAttribute("servlet") != null) {  %>
        
        <a style="margin: 10px" href="?logout=1" ><button class="btn btn-danger" style="width: 100px"> Exit </button></a>
        <% } %>
        
    </body> 
</html>
