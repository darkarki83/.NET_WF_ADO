<%-- 
    Document   : reg
    Created on : Apr 17, 2021, 11:58:25 PM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    </head>
    <body>
        <% String msg = (String) request.getAttribute("regMassage");
             if (msg != null) {%>
        <h1> <%= msg%> </h1>
        <%}%>

        <h1>Registration new User</h1>
        <form method="POST" enctype="multipart/form-data" >

            <div class="form-group">
                <label for="inputName">Name</label>
                <input id="inputName" type="text" class="form-control" name="username" placeholder="Enter name" required>
            </div>       
            <div class="form-group">
                <label for="inputPassword">Password</label>
                <input id="inputPassword" type="password" class="form-control" name="userpass" placeholder="Password" required>
            </div>
            <div class="form-group">
                <label for="inputConfirm">Confirm</label>
                <input id="inputConfirm" type="password" class="form-control" name="userpass2" placeholder="Password" required>
            </div>
            <div class="form-group">
                <label for="inputEmail1">Email address</label>
                <input id="inputEmail1"  type="email" class="form-control" name="useremail" placeholder="Enter email">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
             <div class="form-group">
                <label for="inputAvatar">Avatar</label>
                <input id="inputAvatar" type="file" class="form-control" name="useravatar">
            </div>
            <button type="submit" class="btn btn-primary">Registration</button>    
        </form>
        <a href="auth"><button style="margin-top: 20px" type="submit" class="btn btn-danger">Login</button></a>
    </body>
</html>
