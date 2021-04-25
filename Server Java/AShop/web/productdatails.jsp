<%-- 
    Document   : productdatails
    Created on : Apr 21, 2021, 11:31:59 PM
    Author     : artem
--%>
<%@page import="java.util.ArrayList"%>
<%
    orm.Product theProduct = (orm.Product) request.getAttribute("theProduct");
    orm.User theProductAuthor = (orm.User) request.getAttribute("theProductAuthor");
    ArrayList<orm.ProductComment> comments = (ArrayList<orm.ProductComment>) request.getAttribute("theProductComments");
    orm.User authUser = (orm.User)request.getAttribute("authUser");
%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link 
            rel='stylesheet' 
            href='<%= request.getContextPath()%>/css/productdtl.css' />
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">

    </head>
    <body>
        <div class="wrap-dtl">
            <img src='<%= request.getContextPath()
                    + "/avatarsproduct/"
                    + theProduct.getAvatar()%>' />

            <h1><%= theProduct.getTitle()%> </h1>
            <h3>Seller :
                <i><%= theProductAuthor.getName()%></i>
            </h3>

            <% float pr = theProduct.getPrice() / 100;
                float dis = 100 - theProduct.getDiscount();
                float newP = pr * dis;%>
            <h2 style="margin-top:  100px"> Супер Цена : <%= newP%> $ </h2>
            <div class='clear'></div>
            <p>
                <%= theProduct.getContentFull()%>
            </p>
            <a href='<%= request.getContextPath() + "/shop"%>'><button class="btn btn-danger">To shop</button></a>
            <a href='#'><button class="btn btn-dark">В карзину </button></a>



            <section>
                <h2>Комментарии</h2>
                <b><%= (authUser == null) ? "Аноним" : authUser.getName() %></b>:<br/>
                  <div class="form-group">
                    <textarea class="form-control" id="exampleFormControlTextarea1" rows="3" > </textarea>
                </div>
                <button class="btn btn-light" onclick='addComment()'>Добавить </button>
                <br/>
            </section>
        </div>
        <% if (comments != null) {
                for (orm.ProductComment comment : comments) {%>
        <div class="container alert alert-primary " role="alert">
            <div class="row">
                <div class="col" ><%=comment.getAuthorNik() != null ? comment.getAuthorNik() : "Ananumus"%></div>
                <div class="col"><%= comment.getMoment()%></div>
            </div>
            <div class="row">
                <div class="col" ><%= comment.getCommint()%></div>
            </div>
            <%--<div class="row">
                <div class="col-md-4 offset-md-10"><button class="btn btn-outline-dark">Answer</button></div>
            </div> --%>

        </div>
        <% }
            }%>

        <script>
            function addComment() {
                // id product
                const idProduct = <%= theProduct.getId()%>;
                // id author
                const idAuthor = <%= (authUser == null) ? 0 : authUser.getId()%>;
                // comment text
                const ta = document.querySelector('section textarea');
                if (!ta) {
                    throw "textarea not found";
                }
                const txt = ta.value;

                if (txt.length < 3) {
                    alert("Comment most small");
                    return;
                }
                fetch('<%= request.getContextPath() + "/shop"%>', {
                    method: "POST",
                    body: `idProduct=\${idProduct}&idAuthor=\${idAuthor}&txt=\${txt}`,
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                        .then(r => r.text())
                        .then(res => {
                            if (res == "1") {
                                location = location;
                            } else {
                                alert("Server bug" + res);
                            }

                        });

                //console.log( idProduct + " " + idAuthor + " " + txt);

            }
        </script>
    </body>
</html>
