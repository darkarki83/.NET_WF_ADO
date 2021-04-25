<%-- 
    Document   : index
    Created on : Apr 16, 2021, 3:59:47 AM
    Author     : artem
--%>

<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%  ArrayList<orm.Product> products = (ArrayList<orm.Product>) request.getAttribute("theProducts");
    session = request.getSession();
    session.getAttribute("name");
    String user = "User";
%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="<%=request.getContextPath()%>/css/shop.css"/>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous"/>
    </head>
    <body>
        <nav class="navbar navbar-expand-lg navbar-expand-lg bg-light">
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item">
                        <a class="nav-link " href='<%=request.getContextPath() + "/shop"%>'>Home</a>
                    </li>
                </ul>
                <form class="form-inline my-2 my-lg-0">
                    <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search">
                    <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
                </form>
            </div>
            <a class="nav-link<%=session.getAttribute("name") == null ? " disabled" : ""  %> "  href='<%=request.getContextPath() + "/cabmin"%>'>Cabinet</a>
            <a class="nav-link bg-light" href='<%=request.getContextPath() + "/adminusers"%>'>Admin panel</a>
            <a class="nav-link bg-light" href='<%=request.getContextPath() + "/moder"%>'>Moder</a>

            <%if (session.getAttribute("name") != null) {
                user = (String) session.getAttribute("name");%>
            <span class="my-2 my-lg-0">Hi <%=user%> </span>
            <span> <a style="margin: 10px" href="?logout=1" ><button type="button"  class="btn btn-dark">logout</button></a></span>
            <%}%>

    </nav>

    <ul class="products clearfix">
        <% if (products != null) {
                    for (orm.Product product : products) {
                        if(product.getBlocked() == 0) {%>
                                  
        <li class="product-wrapper" style="margin: 10px">
            <span class="products">
                <div class="product-photo">
                     <img src='<%=request.getContextPath()
                                 + "/avatarsproduct/" + product.getAvatar()%>' alt="">
                </div
                
                <p><i><b> <%=  product.getSummary()%> </b></i></b>
                <p> <%=  product.getContentFull()%> </p>
                <b class="product-price-old" style="color: #ff3535; text-decoration:line-through "><%= product.getPrice()%> $</b>
                <% float pr = product.getPrice() / 100;
                    float dis = 100 - product.getDiscount();
                    float newP = pr * dis;%>
                <b> <%= newP%> $ </b>
                <br/>
                <div style="margin-top: 5px">
                    <a href='<%=request.getContextPath() + "/shop/" + product.getId()%>'><button style="font-size:x-small " class=" btn btn-danger"> Быстрый просмотр </button></a>
                    <button style="font-size:x-small " class="btn btn-dark" > В корзину </button>
                </div>
            </span>
        </li>
        
                <% }
               }
            }%>
    </ul>
</body>
</html>
