<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <title>FileWork</title>
    <style>
        #open {
            font-size: 25px;
            width: 200px;
            margin-left: 35px;
        }

    </style>
</head>
<body style="font-size: 25px">
<h1 style="color:brown">Поиск Файлов по Маске</h1>
<div style="width:600px;height: 100px;background-color: burlywood">
    <table>
        <form method="post" action="" >
            <tr>
                <td>
                    <input style="font-size: 25px" type ="text" name="mask" value="*.txt" required>
                </td>
                <td>
                    <?php
                        openSelect();
                    ?>
                </td>
            </tr>
            <tr>
                <td><input style="font-size: 25px" type ="text" name="file" ></td>
                <td>
                   <input id="open" type="submit" name="open" value="Open">
                </td>
            </tr>
            <tr>
                <td><input type="submit" name="search" value="Search"></td>
            </tr>
        </form>
    </table>
</div>
</body>
</html>
<?php

searchFile();
    //$fileMask = transform();


function openSelect()
{
    if (isset($_REQUEST['open'])) {
        $dir = $_REQUEST['op'];

        $new = "";

        @chdir($dir);

        if ($dir) {
            $new = urldecode($dir);
        }

        $handle = @opendir($new);

        echo '<select name="op" style="font-size: 25px; width: 200px; margin-left: 35px ">';

        while ($elem = @readdir($handle)) {
            if (($elem != ".") && ($elem != "..")) {
                $path = $new . "/" . $elem;

                if (is_dir($path)) {
                    $path = rawurlencode($path);
                    echo "<option value=" . $path . ">" . $elem . "</option>";

                } else echo $elem . "<br>";
            }
        }

        echo "</select>";

    } else {
        echo '<select name="op" style="font-size: 25px; width: 200px; margin-left: 35px ">';
        echo "<br>";
        for ($i = 'A'; $i <= 'Z'; $i++) {
            if (@diskfreespace($i . ":")) {
                $disk = $i . ":";
                echo "<option value=" . $disk . ">" . $disk . "</option>";
            }
        }
        echo "</select>";
    }
}

function searchFile() {

    if (isset($_REQUEST['search']) ) {
        $mask = transform();

        $dir = $_REQUEST['op'];

        $new = "";
        if ($dir) {
            $new = urldecode($dir);
        }

        $handle = @opendir($new);

        while ($elem = @readdir($handle)) {

            if (($elem != ".") && ($elem != "..")) {
                if (chackFile($elem)) {
                    echo $elem;
                    echo '<br>';

                    if(isset($_REQUEST['file']) && strlen($_REQUEST['file']) > 0) {

                        $file = file_get_contents($new . './' . $elem);
                        $pos = strripos($file, $_REQUEST['file']);

                        if($pos === false) {
                            echo "К сожалению, не найдено";
                            echo '<br/>';
                        }
                        else {
                            echo 'Последнее вхождение строчка = ' . strripos($file, $_REQUEST['file']);
                            echo '<br>';
                        }
                    }

                }
            }
        }
    }
}

function transform(){
    $mask = $_REQUEST['mask']; ///   if(. => /.) ^ ? ? .
    $transMask = "";

     for($i = 0 ;$i < strlen($mask);$i++)
     {
         if($i == 0) {
             $transMask .= '/';
         }
         else {
             $transMask .= $mask[$i];
         }
     }
    $transMask .= '$/';
    return $transMask;
}

function chackFile($text){

    $pattern = transform();

    return preg_match($pattern ,$text) == 1 ? true : false;
}























?>