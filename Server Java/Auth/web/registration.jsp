<%-- 
    Document   : registration
    Created on : Mar 31, 2021, 11:48:34 PM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Registration</title>
        <link rel="stylesheet" href="css/style.css"/>
    </head>
    <body>
        <% String msg = (String)request.getAttribute("regMassage");
            if(msg != null) {   %>
            <h1> <%= msg %> </h1>
            <%} %>

        <h1>Reg new User</h1>
        <form method="POST" enctype="multipart/form-data" >
            <span class="form-span">Name</span><input type="text" name="username" required><br/>
            <span class="form-span">Nik</span><input type="text" name="usernik" required><br/>
            <span class="form-span">Pass</span><input type="password" name="userpass" required><br/>
            <span class="form-span">Confirm</span><input type="password" id="userpass2" required><br/>
            <span class="form-span">Email</span><input type="email" name="useremail" required><br/>
            <span class="form-span">Avatar</span><input type="file" name="useravatar"><br/>
            <button>Registration</button>       
        </form>
    </body>
</html>
