<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <style>
        #grid {
            display: grid;
            height:200px;
            grid-template-rows: 15% 1fr 1fr 1fr;
            grid-template-columns: 80%;
            grid-gap: 5%;
            background-color: bisque;
        }

        #l0 {
            margin-left: 10%;
            text-align: center;
        }

        #l4 {
            width: 90%;
            height: 80%;
            margin-left: 10%;
            text-align: center;
            background-color: rebeccapurple;
        }

        #l1 , #l2 {
            margin-left: 10%;
            display: grid;
            grid-template-columns: 25% 75%;
            grid-template-rows: 50%;
        }

    </style>
</head>
<body>
    <form id="grid">
        <div id="l0">
            <label> //\\// Login //\\//</label>
        </div>
        <div id="l1">
            <label style="margin-top: 2px" >Lgin :</label>
            <input type="text" name="login" placeholder="login :" required/>
        </div>
        <div id="l2">
            <label style="margin-top: 2px">Pass :</label>
            <input type="password" name="pass" placeholder="pass :" required/>
        </div>
            <input id="l4" type="submit"  name="adds" value="Add" />
    </form>
<?php chackLogin();
?>
</body>
</html>

<?php

function chackLogin ()
{
    if (isset($_REQUEST['login']) && isset($_REQUEST['pass'])) {
        $log = $_REQUEST['login'];
        $hash = md5($_REQUEST['pass']);

        $file = fopen('log.txt', 'r+');
        $flag = false;
        $wrong = false;

        while (!feof($file)) {
            //$flag = false;
            $str = htmlentities(fgets($file));
            $pass = explode(';', $str);

            if ($pass[0] == $log) {
                if ($pass[1] == $hash) {
                    echo 'Shalom ' . $pass[2] . '<br/>';
                    $flag = true;
                    break;
                } else {
                    echo 'wrong password', PHP_EOL;
                    $wrong = true;
                    break;
                }
            }
        }
        if (!$flag && !$wrong) {
            echo 'no have user wich nick ' . $log . '<br/>';
        }
        return $flag;
    }
}


?>