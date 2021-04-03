<%-- 
    Document   : index
    Created on : Mar 31, 2021, 12:57:12 AM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Hello <%= request.getAttribute("username") %></h1>
        <!--   View reg data + last visit    -->
        <h3>create data : <%= request.getAttribute("regdata") %></h3>
        <h3>last in : <%= request.getAttribute("lastdata") %></h3>

        <% if(request.getAttribute("servlet") != null) {  %>
        <a href="?logout=1"><button style="width: 100px"> Exit </button></a>
        <% } %>
        
    </body> 
</html>
