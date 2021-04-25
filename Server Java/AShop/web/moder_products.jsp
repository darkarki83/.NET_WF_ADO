<%-- 
    Document   : moder_products
    Created on : Apr 23, 2021, 1:52:14 AM
    Author     : artem
--%>
<%@page import="java.util.ArrayList"%>
<%
    orm.User user = (orm.User) request.getAttribute("authUser");
    ArrayList<orm.Product> preducts = (ArrayList<orm.Product>) request.getAttribute("productList");

%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
         <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="<%=request.getContextPath()%>/css/shop.css"/>
  
    </head>
    <body>
        <h3 class="do-it" ><%=user.getName()%> do it</h3>
        <a href="<%=request.getContextPath()%>/shop"><button style="margin: 20px" class="btn btn-danger">To Shop</button></a>

        <div class="add-product" >
            <label> title : </label> <input type="text" name="product-title" /> <br/>
            <label> summary : </label> <textarea name="product-short" ></textarea> <br/>
            <label> contentFull </label> <textarea name="product-full" > </textarea><br/>
            <label> price </label> <input id="inches" type="number" name="product-price" min="0" max="2000" step="1">  <br/>
            <label> discount </label> <input id="inches" type="number" name="product-discount" min="0" max="15" step="0.5">  <br/>
            <label> quentity </label> <input id="inches" type="number" name="product-quentity" min="0" max="100" step="1">  <br/>
            <label> avatar </label> <input type="file" name="product-avatar" /> <br/>
            <button class="btn btn-group" onclick="addProduct()">Added</button>
        </div>
 
        <a href="<%=request.getContextPath()%>/shop"><button style="margin: 20px" class="btn btn-danger">To Shop</button></a>

        <%for (orm.Product preduct : preducts) {%>
        <div class="product-container" style="<%=preduct.getBlocked() != 0 ? "opacity: 0.5" : ""%> ">
            <%--  block blocked news  --%>
            <label><input onchange="toggleProduct(<%=preduct.getId()%>, <%=preduct.getBlocked()%>)" type="checkbox" <%=preduct.getBlocked() != 0 ? "checked" : ""%>/> Blocked </label>
                <% if (preduct.getBlocked() > 0) {%>
            <b> <%=preduct.getBlockedReason()%></b>
            <% } else {%>
            <input name='blocked-reason<%=preduct.getId()%>' />
            <% }%>
            <br/>
            <%--  finish block blocked news  --%>

            <p><img class="img-thumbnail" src="../avatarsproduct/<%= preduct.getAvatar()%>" /></p>
            <h1 onclick="location.href = '<%=request.getContextPath() + "/shop/" + preduct.getId()%>'">
                <%= preduct.getTitle()%></h1>
            <h2><%= preduct.getUserId()%></h2>
            <p><%= preduct.getSummary()%> </p>
            <p><%= preduct.getContentFull()%> </p>
            <p><%= preduct.getPrice()%> </p>
            <p><%= preduct.getDiscount()%> </p>
            <p><%= preduct.getQuentity()%> </p>
        </div>
        <% }%> 

        <script>
            function addProduct() {
                const title = document.querySelector('[name="product-title"]');
                const short = document.querySelector('[name="product-short"]');
                const full = document.querySelector('[name="product-full"]');
                const price = document.querySelector('[name="product-price"]');
                const discount = document.querySelector('[name="product-discount"]');
                const quentity = document.querySelector('[name="product-quentity"]');
                const avatar = document.querySelector('[name="product-avatar"]');
                let data = new FormData();

                data.append("command", "addProduct");
                data.append("title", title.value);
                data.append("short", short.value);
                data.append("full", full.value);
                data.append("price", price.value);
                data.append("discount", discount.value);
                data.append("quentity", quentity.value);
                data.append("avatar", avatar.files[0]);
                const url = '<%=request.getContextPath()%>/moder/';

                fetch(url, {
                    method: "POST",
                    body: data
                }).then(r => r.text())
                        .then(txt => {
                            if (txt == "success") {
                                location = location;
                            } else {
                                alert(txt);
                            }
                        });
            }

            function toggleProduct(nid, blocked) {
                //console.log(nid);
                let reason = "";
                if (blocked == 0) {

                    let reasonInput = document.querySelector(`input[name="blocked-reason\${nid}"]`);
                    if (!reasonInput) {
                        throw "input not found";
                        return false;
                    }
                    reason = reasonInput.value;
                    if (reason == "") {
                        alert("input reason");
                        event.target.cheched = false;
                        event.preventDefault();
                        return false;
                    }
                }

                const url = '<%= request.getContextPath()%>/moder/';
                fetch(url, {
                    method: "POST",
                    body: "command=toggleProduct&cid=" + nid + "&reason=" + reason,
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                }).then(r => r.text())
                        .then(txt => {
                            if (txt == "success") {

                                location = location;
                            } else {
                                alert(txt);
                            }
                        });

            }
        </script>
    </body>
</html>
