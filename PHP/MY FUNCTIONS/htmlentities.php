﻿<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
</head>
<body>
<div>
<?php
if(isset($_REQUEST['login']) && isset($_REQUEST['password'])){

// htmlentities() преобразует все символы в соответствющие HTML-сущности (для тех символов, для которых HTML сущности существуют)
   $login = htmlentities($_REQUEST['login']);
    $password = htmlentities($_REQUEST['password']);
    echo "Ваш логин: $login <br> Ваш пароль: $password";
}
?>
</div>
<h3>Вход на сайт</h3>
<form method="POST">
    Логин: <input type="text" name="login" /><br><br>
    Пароль: <input type="password" name="password" /><br><br>
    <input type="submit" value="Отправить">
</form>
</body>
</html>