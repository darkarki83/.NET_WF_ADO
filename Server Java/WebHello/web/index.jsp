<%-- 
    Document   : index
    Created on : Mar 19, 2021, 12:17:29 AM
    Author     : artem
--%>

<%@page import="model.Db"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%
    String[] str = new String[]{"str 1", "str 2", "str 3", "str 4"};
    model.Db db = new Db();

    // Controler work 
    String uid = request.getParameter("uid");
    String userName = request.getParameter("username");

    System.out.println(uid);
    System.out.println(userName);

    boolean status;
    // режим редактирования
    if (userName != null && uid != null) {
        // Собрать все данные - подготовить объект model.orm.User
        model.orm.User u = new model.orm.User();
        u.setName(userName);
        u.setId(Integer.parseInt(uid));
        // Передать его в Модель
        status = db.editUser(u);
        // "Сброс параметров" - переадресация на страницу без параметров
        response.sendRedirect(request.getRequestURI());
    } else if (uid != null) {
        // Работа с данными - задача Модели
        status = db.deleteUser(Integer.parseInt(uid));
        // "Сброс параметров" - переадресация на страницу без параметров
        response.sendRedirect(request.getRequestURI());
    } else if (userName != null) {
        // Собрать все данные - подготовить объект model.orm.User
        model.orm.User u = new model.orm.User();
        u.setName(userName);
        // Передать его в Модель
        status = db.addUser(u);
        // "Сброс параметров" - переадресация на страницу без параметров
        response.sendRedirect(request.getRequestURI());
    }


%> 

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Hello, Web</title>
    </head>
    <body>
        <h1>JSP</h1>
        <p>JSP - Java Server Pages - технология разработки web-приложений
            с активностью на стороне сервера<br/>
            HTML (статичные страницы) - без активности<br/>
            WebAPI (SPA) - с распределенной активностью
        </p>
        <p>
            Data(Model) - Controller - View
            ASP/PHP/JSP - Server Activity<br/>
            
            ( Data(Model) - Controller )  --API-- ( Controller, View )
        </p>
        <% if (true) {  %>
        <h3>True</h3>
        <% } else {  %>
        <h3>False</h3>
        <% } %>

        <table  border="1">

            <%-- add user --%>
            <form method="post">
                <label> add new user : </label>
                <input name="username" required > 
                <button type="submit"> add </button>
            </form>


            <% for (model.orm.User us : db.getUsersList()) {%>
            <tr>
                <td><%= us.getId()%></td>
                <td onClick="userClick(event)"><%= us.getName()%></td>
                <td><a href="?uid=<%= us.getId()%>">delete </a></td>
                <td><a href="?uedit=<%= us.getId()%>">edit </a></td>
            </tr>
            <% }%>
        </table>

        <script>
            function userClick(e) {
                
                //console.log(e.target.innerText, e.target.previousElementSibling.innerText);
                e.target.contentEditable = true;
                //e.target.onblur = endEdit;
                e.target.onkeydown = endDown;
                e.target.focus();
            }

            function endEdit(e) {
                console.log(e.target.innerText, e.target.previousElementSibling.innerText);
                e.target.contentEditable = false;
                e.target.onblur = undefined;
            }

            function endDown(e) {
                if (e.keyCode == 13) {

                    e.preventDefault();

                    location.href = location.origin + location.pathname +
                            "?uid=" + e.target.previousElementSibling.innerText +
                            "&username=" + e.target.innerText;
                    console.log(e.target.innerText, e.target.previousElementSibling.innerText);
                    // console.log(editedName, uid);
                    return false;
                }
            }

        </script>
        <!--Commint - in HTML -->
        <%--Commint - not see HTML --%>   
    </body>
</html>
