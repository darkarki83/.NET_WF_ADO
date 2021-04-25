<%-- 
    Document   : moder
    Created on : Apr 22, 2021, 2:36:43 AM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Moderater</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        
    </head>
    <body>
        <div style="text-align: center">
        <h1>Hello Moderater!</h1>
        
        <a href="<%=request.getContextPath()%>/moder/comment"><button class="btn btn-link" >Comments </button></a>
        <a href="<%=request.getContextPath()%>/moder/news"><button class="btn btn-link" >News </button></a>
        </div>
        </body>
</html>
