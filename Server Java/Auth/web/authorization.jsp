<%-- 
    Document   : authorization
    Created on : Apr 2, 2021, 3:06:09 AM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Authorization</title>
           <style>
            .form-span {
                display: inline-block;
                width: 100px;
            }
        </style>
    </head>
    <body>
        <h1>Authorization</h1>
        <form method="POST" >
            <span class="form-span">Login</span><input type="text" name="login" required><br/>
            <span class="form-span">Pass</span><input type="password" name="pass" required><br/>
            <button style="width: 250px; margin: 10px" >Login</button>       
        </form>
        
        <% String msg = (String)request.getAttribute("authMassage");
            if(msg != null) {   %>
            <h1> <%= msg %> </h1>
            <%} %>
    </body>
</html>
