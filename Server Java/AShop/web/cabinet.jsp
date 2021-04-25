<%-- 
    Document   : cabinet
    Created on : Apr 22, 2021, 11:18:41 PM
    Author     : artem
--%>

<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    orm.User user = (orm.User) request.getAttribute("authUser");
    ArrayList<orm.ProductComment> comments = (ArrayList<orm.ProductComment>) request.getAttribute("comments");
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Cabmin</title>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="<%=request.getContextPath()%>css/style.css"/> 
    </head>
    <body>
        <div id="all">
            <h2>Hi <%=user.getName()%></h2>
            <h2><%=user.getEmail()%></h2>
            <h2><img style="width: 200px" src="avatars/<%=user.getAvatar()%>"/></h2>
            <button class="btn btn-dark m-1" onclick="editBtn()">Edit</button>
            <a href="<%= request.getContextPath()%>/shop"><button class="btn btn-danger " >To shop</button></a>
            
        </div>


        <form id="form" style="display: none"  method="POST" enctype="multipart/form-data" >
            <div class="form-group">
                <label for="name">Name</label>
                <input type="text" name="username" class="form-control" id="name" aria-describedby="name" placeholder="Enter name">
            </div>
            <div class="form-group">
                <label for="pass">Pass</label>
                <input type="password" name="userpass" class="form-control" id="pass" aria-describedby="name" placeholder="Enter password">
                <label style="display: none; color: red" id="passlabel">Pass not match</label>
            </div>
            <div class="form-group">
                <label for="pass1">Confirm</label>
                <input type="password" name="userpass2" class="form-control" id="pass1" aria-describedby="name" placeholder="Confirm password">
            </div>
            <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <input type="email" name="useremail" class="form-control" id="exampleInputEmail1" aria-describedby="emailHelp" placeholder="Enter email">
                <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
            </div>
            <div class="form-group">
                <label for="avatar">Avatar</label>
                <input type="file"  name="useravatar" class="form-control" id="avatar" name="useravatar" aria-describedby="file" placeholder="Enter name">
            </div>
            <button type="submit" class="btn btn-primary" onclick="editBtn()">Save</button>    
            <a class="btn btn-primary" href="<%= request.getContextPath()%>/cabmin">Back</a>
        </form>

        <div id="comm" style="text-align: center" > Your comments 
            <% if (comments != null) {
                for (orm.ProductComment comment : comments) {%>
            <div class="container alert alert-<%= comment.getBlocked() == 0 ? "primary" : "danger"%>" role="alert">
                <div class="row"> 
                    <div class="col"><%= comment.getMoment()%></div>
                </div>
                <div class="row">
                    <div class="col" ><%= comment.getCommint()%></div>
                </div>
                <div class="row">
                    <div class="col" >Preduct ID <%= comment.getIdProduct()%></div>
                </div>
                <div class="row">
                    <div class="col" >Blocked <%= comment.getBlocked()%></div>
                </div>
            </div>
            <% }
            }%>
        </div>
    </div>
    <script>
        const form = document.getElementById("form");
        const div = document.getElementById("all");
        const comm = document.getElementById("comm");

        function editBtn() {
            if (form.style.display == 'none') {
                form.style.display = 'block';

                div.style.display = 'none';
                comm.style.display = 'none';
            } else {
                form.style.display = 'none';
                div.style.display = 'block';
                comm.style.display = 'block';
            }
        }
    </script>
    <% if (request.getAttribute("restart") != null) { %>
    <script>location = location;</script>
    <% } %>
    <% if (request.getAttribute("error") != null) { %>
    <script>
        editBtn();
        const label = document.getElementById("passlabel");
        label.style.display = 'block';
    </script>
    <% }%>
</body>
</html>
