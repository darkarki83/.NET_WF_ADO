<%-- 
    Document   : auth
    Created on : Apr 18, 2021, 2:07:23 AM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    </head>
    <body>
        <h1>Authorization</h1>
        <form method="POST">
            <div class="form-group">
                <label for="inputName">Name</label>
                <input type="text" name="login" class="form-control" id="inputName" placeholder="Enter name" required>
                <small class="form-text text-muted">We'll never share your name with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="inputPassword1">Password</label>
                <input type="password" name="pass" class="form-control" id="inputPassword1" placeholder="Password" required>
            </div>
            <button style="width: 250px; margin-top: 10px" type="submit" class="btn btn-primary">Login</button>
        </form>
        <a href="reg"><button style="width: 250px; margin-top: 20px" class="btn btn-danger">Registration</button></a>
        <% String msg = (String) request.getAttribute("authMassage");
            if (msg != null) {%>
        <h1> <%= msg%> </h1>
        <%}%>
    </body>
</html>
