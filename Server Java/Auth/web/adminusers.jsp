<%-- 
    Document   : adminusers
    Created on : Apr 7, 2021, 12:44:58 AM
    Author     : artem
--%>

<%@page import="java.util.Map"%>
<%@page import="java.util.HashMap"%>
<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
        <link rel="stylesheet" href="css/style.css"/>
              <title>Admin</title>
    </head>
    <body class="bg-light" >
        <h1>Admin users</h1>
        <%  ArrayList<orm.User> users = (ArrayList<orm.User>) request.getAttribute("users");
            ArrayList<orm.Role> roles = utilits.RoleUtil.getList();
            Map<Integer, String> titles = new HashMap<Integer, String>();
            int i = 1;
            for (orm.Role role : roles) {
                titles.put(i, role.getTitle());
                i++;
            }
        %>
        Зарегистрировано пользователей: <b><%= users.size()%></b>
        <br>
        <table class="table-hover" border="2"  >            
            <tr>
                <td> Id </td>
                <td> login </td>
                <td> name </td>
                <td> email </td>
                <td> avatar </td>
                <td> regMoment </td>
                <td> authMoment </td>
                <td> roleFk </td>
                <td> action </td>
            </tr>
            <%for (orm.User user : users) {%>
            <tr>
                <td><%= user.getId()%></td>
                <td><%= user.getNik()%></td>
                <td><%= user.getName()%></td>
                <td><%= user.getEmail()%></td>
                <td><img class="img-thumbnail"  style="width: 100px; margin: 10px" src="avatars/<%= user.getAvatar()%>" /></td>
                <td><%= user.getRegMoment()%></td>
                <td><%= user.getAuthMoment()%></td>
                <td >
                    <span>
                        <%=titles.get(user.getRoleFk())%> 
                    </span>
                    <select class="role-hidden">
                        <%for (orm.Role role : roles) {%>
                        <option
                            value="<%=role.getId()%>"
                            <%= (role.getId() == user.getRoleFk()) ? "selected" : ""%>
                            >
                            <%=role.getTitle()%>
                        </option> 
                        <%}%>
                    </select>
                </td>
                <td>
                    <div class="tool-btn del-btn" onclick="delClick(<%= user.getId()%>)"></div>
                    <div class="tool-btn edit-btn" onclick="editClick(<%= user.getId()%>)"></div> 
                </td>
            </tr>
            <% }%>
        </table>
        <br/>

        <select>
            <%for (orm.Role role : roles) {%>
            <option
                value="<%=role.getId()%>"
                <%= (role.getId() == 2) ? "selected" : ""%>
                >
                <%=role.getTitle()%>
            </option> 
            <%}%>
        </select>

        <script>
            function delClick(uid) {
                if (confirm("Delete uder id=" + uid)) {

                    fetch(location.pathname + "?uid=" + uid, {
                        method: "DELETE"
                    })
                            .then(r => r.json())
                            .then(j => {
                                alert(j.msg);
                                if (j.status == "success") {
                                    location = location;
                                }
                            });
                }
            }

            function editClick(uid) {
                //confirm("Edit uder id=" + uid);
                const element = event.target; // нажатый блок
                const sel = element.closest("tr").querySelector("select"); // select ролей
                const span = element.closest("tr").querySelector("span");

                if (element.classList.contains("edit-btn")) { // нажата в режиме edit
                    element.classList.replace("edit-btn", "done-btn");
                    sel.classList.remove("role-hidden");
                    span.classList.add("role-hidden");
                } else { // нажата в режиме done
                    const idRole = sel.value;
                    // Самостоятельно - проверить есть ли изменения
                    
                    
                    //console.log(idRole);
                    // Отправка изменений на сервер (AJAX)
                    fetch(location.pathname + "?uid=" + uid + "&id_role=" + idRole, {
                        method: "POST",
                        headers: {
                            'Content-Type': 'application/x-www-form-urlencoded'
                        }
                    })
                            .then(r => r.json()) // Получение ответа от сервера
                            .then(j => {
                                alert(j.msg);
                                if (j.status == "success") {
                                    location = location;
                                }
                            });

                    element.classList.replace("done-btn", "edit-btn");
                    sel.classList.add("role-hidden");
                    span.classList.remove("role-hidden");
                }
            }
        </script>
    </body>
</html>
