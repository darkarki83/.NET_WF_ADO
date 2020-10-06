<?php

    $myuser = fopen('user.txt', 'r+') or die('can not open the file');

    $index = 0;
    echo '<table>';
    while(!feof($myuser)) {

        if($index > 0) {
            $str = htmlentities(fgets($myuser));
            $str = explode(';', $str)[0];
            if(strlen($str) > 0) {
                echo '<tr>';
                echo '<td>' . 'Nick :' . $str . '</td>';
                echo '</tr>';
            }
        }
        else {
            htmlentities(fgets($myuser));
            echo '<tr><td>all nicks </td></tr>';
            $index++;
        }
    }
    echo '</table>';

?>