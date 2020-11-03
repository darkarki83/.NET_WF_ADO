<?php

function Choice() {

    if(isset($_REQUEST['country'])) {

        $link = mysqli_connect("127.0.0.1", "root", "ariall83", "city_country");

        if (!$link) {
            echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
            exit;
        }

        $query = "select cities.city from cities where countries_fk = " . $_REQUEST['country'] . ";";

      /*  if ($result = mysqli_query($link, $query)) {

            while ($row = $result->fetch_row()) {
                echo "<option value='$row[0]'>$row[0]</option>";
            }*/
           // $result->close();
        ////}
        mysqli_close($link);
    }
}










?>
