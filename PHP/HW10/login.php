

<?php

if(isset($_REQUEST['password']) && isset($_REQUEST['login'])) {

    $login=$_POST['login'];
    $pass=$_POST['password'];


    if($login=="art" && $pass=="kr"){
        echo "Авторизация прошла успешно";
    }
    else{
        echo "Неверно введен логин или пароль";
    }

}

if(isset($_REQUEST['login'])) {

    $login = $_REQUEST['login'];
    $flag = false;

    $link = mysqli_connect("127.0.0.1", "root", "ariall83", "my_account");
    if(!$link) {
        echo "Error : No connect to DB" . PHP_EOL;
        exit;
    }

    $query = " select acc.login from acc;";

    if($result = mysqli_query($link, $query)) {

        while ($row = $result->fetch_row()) {

            if($login == $row[0]) {
                $flag = true;
                break;
            }
        }

        $result->close();
    }

    echo $flag;
}
?>
