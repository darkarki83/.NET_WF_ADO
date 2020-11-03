<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
</head>
<body>

<h1>YOUR CHOICE !!!</h1>

<form id="myform" action="lists.php" method="post">
    <div style="margin: 50px">
        <select id="myselect" name="country" style="width: 50%" ch>
        <?php
        Country();
        ?>
        </select>
        <?php
        //Choice();
        ?>
    </div>
</form>

<script type="text/javascript">

    /*let xmlHttp = new XMLHttpRequest();

    $(function(){
        $("#myselect").change(function(){
            $("#myform").submit();
        });
    });*/

    $(function(){
        $("#myselect").change(function(event) {

            $("#myform").submit();
            event.preventDefault();

            $.ajax({
                url: $("#myform").attr('action'),
                data: $("#myselect").serialize(),
                type: 'POST',
                // Функция, код которой будет выполнен если запрос будет завершен успешно.
                success: function(data){

                    console.log(data.arr);
                },
                // Функция, код которой будет выполнен если во время исполнения запроса произойдет ошибка.
                error: function (x, y, z) {
                    alert(x + '\n' + y + '\n' + z);
                }
            });
        });
    });

</script>
</body>
</html>

<?php

//echo $_REQUEST['country'];

Choice();

function Country() {

    $link = mysqli_connect("127.0.0.1", "root", "ariall83", "city_country");

    if (!$link) {
        echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
        exit;
    }

    $query = "select countries.id, countries.name from countries;";

    echo "<option value='0'></option>";
    if($result = mysqli_query($link, $query)) {

        while($row = $result->fetch_row()) {
            echo "<option value='$row[0]'>$row[1]</option>";
        }
        $result->close();
    }

    mysqli_close($link);
}

function Choice() {

    $arr = array();
    if(isset($_REQUEST['country'])) {

        $link = mysqli_connect("127.0.0.1", "root", "ariall83", "city_country");

        if (!$link) {
            echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
            exit;
        }

        $query = "select cities.id, cities.city from cities where countries_fk = " . $_REQUEST['country'] . ";";
        if ($result = mysqli_query($link, $query)) {

            while ($row = $result->fetch_row()) {

                $arr[] = $row[1];
            }
            $result->close();
        }

        mysqli_close($link);

        echo '<div id="result" style="margin: 50px">';
        foreach ($arr as $value ) {
            echo $value . "<br />";
        }
        echo '</ div>';

        json_encode($arr);
    }
}
?>
