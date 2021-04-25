<%-- 
    Document   : news
    Created on : Apr 13, 2021, 3:34:49 AM
    Author     : artem
--%>

<%@page import="java.util.ArrayList"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
  <%  ArrayList<orm.News> news = (ArrayList<orm.News>) request.getAttribute("news");

  %>

<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
        <link rel="stylesheet" href="css/style.css"/>
        <link rel="stylesheet" href="<%=request.getContextPath()%>/css/news.css"/>
    </head>
    <body>
        <h1>Самые свежие</h1>
        
       
        количество новостей: <b><%= news.size()%></b>
        <br>
            <%for (orm.News onenews : news) {
                if(onenews.getBlocked() == 0 ) {%>
                
            <%--<tr class="news-container" >
                <td><%= onenews.getId()  %></td>
                <td><%= onenews.getTitle() %></td>
                <td><%= onenews.getContentShort() %></td>
                <td><%= onenews.getContentFull() %></td>
                <td><%= onenews.getMoment() %></td>
                <td><%= onenews.getIdAuthor() %></td>
                <td><img class="img-thumbnail"  style="width: 100px; margin: 10px" src="newsavatars/<%= onenews.getAvatar() %>" /></td>
                <td>
                    <div class="tool-btn del-btn" onclick="delClick(<%= onenews.getId()%>)"></div>
                    <div class="tool-btn edit-btn" onclick="editClick(<%= onenews.getId()%>)"></div> 
                </td>
            </tr>--%>
            
            <div class="news-container">
                <p><img class="img-thumbnail" src="newsavatars/<%= onenews.getAvatar() %>" /></p>
                <h1 onclick="location.href='<%=request.getContextPath() + "/news/" + onenews.getId()%>'">
                    <%= onenews.getTitle() %></h1>
                <h2><%= onenews.getMoment() %></h2>
                <p><%= onenews.getContentShort() %></p>
            </div>
            <% }%> 
            <% }%>     
    </body>
</html>
