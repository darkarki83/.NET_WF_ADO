<%-- 
    Document   : load
    Created on : Mar 27, 2021, 4:29:48 PM 
    Author     : artem
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
       <title>HelloWeb</title>
    </head>
    <body>
        <h1>Load: files uploading / downloading</h1>
        <h2>Теория</h2>
        <p>
            Загрузка файлов рассматривается в двух аспектах:<br/>
            server &rarr; client - downloading<br/>
            server &larr; client - uploading<br/>
            download - файл извлекает браузер, сохраняем в указанном месте<br/>
            upload - файл извлекает сервер (ПО) и сохраняет в временном хранилице.
            если файл нужен, его необходимо переместить в постоянное хранилище
        </p>
        <p>
            При передачи файла его имя указывается в специальном заголовке
            Content-Disposition: attachment; filename=file.txt<br/>
            Content-Type: application/pdf <i>PDF</i><br/>
            Content-Type: application/octet-stream <i>Binary</i><br/>
            Content-Type: text/plain <i>Text</i><br/>
        </p>
        <h2>Downloading</h2>
        <p>
            Передача файла с сервера к клиенту. 
            Большинство серверов настроены таким образом, чтобы автоматически "отдавать"
            файлы, если запрос - это их имя.
            Задача загрузки - контроллируемо передать файл.<br/>
            Для реализации загрузки достаточно GET-запроса, то есть ссылка<br/>
            <!--<a href="?filename=java_logo.png">java_logo.png</a><br/>-->
            <br/>
            Скачивание или открытие в браузере?<br/>
            Content-Disposition: inline (default) - открытие в браузере<br/>
            ! Браузер не будет открывать незнакомые форматы данных, в т.ч. бинарный поток<br/>
            Content-Disposition: attachment  - Скачивание<br/>
            Сontent-Type: application/octet-stream   - Скачивание при любом Content-Disposition<br/>
        </p>
        <h2>Uploading</h2>
        <p>
            1. Форма: method="POST" enctype="multipart/form-data"<br/>
            2. input type="file" name="userfile" <br/>
            3. Со стороны сервера - Сервлет с методом POST<br/>
            4. Сервлет должен быть конфигурирован для работы с multipart 
            (иначе 500 - Request.getPart is called without multipart configuration.)            <br/>
            
        </p>
        <form  method="Post" enctype="multipart/form-data">
            choice file : 
            <input type="file" name="clientfile"/>
            about file : <input name="description" />
            <button type="submit"> Send </button>
        </form>
        <% if(request.getAttribute("filename") != null){ %>
            получин фаил <b> <%= request.getAttribute("filename") %></b>
            <br/>
            <!-- Download file from Servet -->
            <form  method="GET" enctype="multipart/form-data">
                <input type="file" name="filename"/>
                <button type="submit"> Download </button>
            </form>
            
           
            <% if(request.getAttribute("filename").toString().substring(request.getAttribute("filename").toString().length() - 3).equals("png") || 
                    request.getAttribute("filename").toString().substring(request.getAttribute("filename").toString().length() - 3).equals("jpg") ||
                    request.getAttribute("filename").toString().substring(request.getAttribute("filename").toString().length() - 3).equals("gif")) {  %>
            <img src="<%= request.getAttribute("filename") %>"/>
            <% } %>
            <% } %>
            <br/>
            <%
            if(request.getAttribute("description") != null){ %>
            описание : <b> <%= request.getAttribute("description")%></b>
            <% } %>
            <br/>
    </body>
</html>
