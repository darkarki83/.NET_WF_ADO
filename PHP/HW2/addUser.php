<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <style>
        body {
            font-size: 20px;
        }

        #grid {
            display: grid;
            width: 66%;
            grid-template-columns: 48% 48%;
            grid-auto-flow: row;
            grid-gap: 1em;
            background-color: deepskyblue;
            padding: 1em;

        }

        #grid > #reg {
            grid-column: span 2;
            text-align: center;
        }

        #grid > #gridsub {
            grid-column: span 2;
            text-align: center;
        }

    </style>
    <body>
        <form id="grid" action="addUser.php" method="post">
            <label id="reg">Registration</label>
            <label > Nick: </label>
            <input type="text" name="nickinput" style="font-size: 20px;" required/>
            <label > Password: </label>
            <input type="password" name="pass1" style="font-size: 20px;" required/>
            <label > Confirm: </label>
            <input type="password" name="pass2" style="font-size: 20px;" required/>
            <label > Email: </label>
            <input type="email" name="email" style="font-size: 20px;" required/>
            <input id="gridsub" type="submit" name="add" value="add" style="font-size: 20px">
        </form>
    </body>
</html>

<?php
$add_info = "";
$nick = null;

if(isset($_REQUEST['nickinput'])) {
    $nick = $_REQUEST['nickinput'];
    $add_info .= $nick . ";";
}

if(isset($_REQUEST['pass1'])) {
    $pass1 = $_REQUEST['pass1'];
    $add_info .= md5($pass1) . ";";
}

if(isset($_REQUEST['email'])) {
    $email = $_REQUEST['email'];
    $add_info .= $email . ";\n";
}

if(isset($_REQUEST['nickinput']) && isset($_REQUEST['pass1']) && isset($_REQUEST['email'])) {

    if(eqvivalent($nick)) {
        saveInFile($add_info);
    }
}

function eqvivalent($nick) {

    $myfile = fopen('log.txt',"r+") or die("не удалось открыть файл");

    while (!feof($myfile)) {
        $str = htmlentities(fgets($myfile));

        $str = explode(';', $str)[0];
        if($str != '') {
            if ($nick == $str) {
                echo "this nick is busy";
                fclose($myfile);
                return false;
            }
        }
    }
    fclose($myfile);
    return true;
}

function saveInFile($add_info) {
    $myfile = fopen('log.txt', 'a') or die("Can not be opened");
    if(fwrite($myfile, $add_info)){
        echo "adding info !";
    }
    else {
        echo "an erroe occurred";
    }
    fclose($myfile);

    $myuser = fopen('user.txt', 'r+') or die("Can not be opened");
    $str = htmlentities(fgets($myuser));
    $tmp = (int)$str + 1;
    fclose($myuser);

    $myuser = fopen('user.txt', 'w') or die("Can not be opened");
    $myfile = fopen('log.txt', 'r+') or die("Can not be opened");

    fwrite($myuser, $tmp . "\n");

    while (!feof($myfile)) {

        $str = explode(';', htmlentities(fgets($myfile)))[0];
        fwrite($myuser, $str . ";\n");
    }

    fclose($myuser);
    fclose($myfile);
}

?>