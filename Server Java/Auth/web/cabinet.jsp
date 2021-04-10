<%-- 
    Document   : cabinet
    Created on : Apr 9, 2021, 3:49:54 AM
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    orm.User user = (orm.User) request.getAttribute("authUser");

%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="css/style.css"/>
        <style>
            .form-hidden {
                display: none;
            }
            .form-visible {
                display: inline-block;
            }
        </style>
    </head>
    <body>
        <h1>Cabinet</h1>
        <%--
        <h1><%= request.getAttribute("fromstarter") %> </h1>
        <h1><%= request.getAttribute("fromfilter") %> </h1>
        <h1><%= request.getAttribute("fromservlet") %> </h1>
        --%>
        <h2><%=user.getNik()%> on site from <%=user.getRegMoment()%></h2>
        <br/>
        <div id="all">
        <h2><%=user.getName()%></h2>
        <h2><%=user.getEmail()%></h2>
        <h2><img style="width: 200px" src="avatars/<%=user.getAvatar()%>"/></h2>
        <button class="btn btn-dark m-1" onclick="editBtn()"  >Edit</button>
        </div>
        
        <form id="form" class="form-hidden" method="POST" enctype="multipart/form-data" >
            <div class="form-group">
                <label for="name">Name</label>
                <input type="text" class="form-control" id="name" aria-describedby="name" placeholder="Enter name">
            </div>
             <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="avatar">Avatar</label>
                <input type="file" class="form-control" id="avatar" name="useravatar" aria-describedby="file" placeholder="Enter name">
            </div>
            <button type="submit" class="btn btn-primary" onclick="Save()">Save</button>       
        </form>
        
        <% if(request.getAttribute("post") != null) { %>
        <h3><%=request.getAttribute("post")%></h3>
        <% } %> 
        
        <script>
            const form =  document.getElementById("form");
            const div =  document.getElementById("all");
            
            function editBtn() {
                div.classList.add("form-hidden");
                form.classList.remove("form-hidden");
            }
            
            function Save() {
                div.classList.remove("form-hidden");
                form.classList.add("form-hidden");
            }
            
            
        </script>
    </body>
</html>
