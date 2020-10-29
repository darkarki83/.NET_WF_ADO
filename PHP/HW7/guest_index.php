<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <style>
        #grid {
            display: grid;
            grid-auto-flow: row;
            height:400px;
            background-color: crimson;
        }

        .gdiv {
            margin: 15px;
            width: 600px;
        }

    </style>
</head>
<body>
    <form id="grid" action="" method="post">
        <div class="gdiv" >
            <label>Name :</label>
            <input  type="text" name="name" required>
        </div>
        <div class="gdiv">
            <label>City :</label>
            <input type="text" name="city">
        </div>
        <div class="gdiv">
            <label>Email :</label>
            <input type="text" name="email">
        </div>
        <div class="gdiv">
            <label>Url :</label>
            <input type="text" name="url">
        </div>
        <div class="gdiv">
            <textarea rows="4" cols="70" name="msg"></textarea>
        </div>
        <div style="text-align: center" >
            <input style="width: 150px" type="submit" name="send" value="Send">
        </div>
    </form>
    <div>
        <a style="margin: 15px" href="manager_index.php">Manaeg Mode</a>
    </div>
</body>
</html>

<?php


   /* $link = mysqli_connect("127.0.0.1", "root", "ariall83", "my_guest_book");

    if (!$link) {
        echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
        exit;
    }

      $query = "select g.id_msg, g.name, g.msg from guest g;";

if ($result = mysqli_query($link, $query))
    {
        echo "<table border='2' width='100%'>";
        while ($row= $result->fetch_row()) {
            echo "<tr>";
            for ($i = 0; $i < count($row); $i++)
                echo "<td>" . $row[$i]. "  " . "</td>";
            echo "<br />"; . echo "</tr>";
        }
        $result->close();
        echo "</table>";
    }
    mysqli_close($link);*/   //!!!!!!!!!!!!!!!work!!!!!!!!!!

add_coment();

try {

    $my_user = "root";
    $pass = "ariall83";
    $db = new PDO('mysql:host=localhost;dbname=my_guest_book', $my_user, $pass);



    $tables = $db->query('SHOW TABLES');
    while ($row = $tables->fetch()) {

        $nametable[] = $row[0];
    }

    $n = count($nametable);
    for ($i = 0; $i < $n; $i++)
    {
        echo "<table style='border-color: #f57b93' border='1' width='100% >";
        echo "<caption style = 'font-size:20pt;font-weight:bold;color:red'>".$nametable[$i]."</caption>";
        echo "<thead><tr>";
        $q = "SHOW COLUMNS FROM ". $nametable[$i];  // отдал названия и тип столбца
        $sth = $db->query($q);


        while($row = $sth->fetch())
        {
                $namecolumn[] = $row[0];
                echo "<th>" . $row[0] . "</th>";
        }

        echo "</tr></thead>";
        $query = "SELECT * FROM " . $nametable[$i];
        $stmt = $db->query($query);
        $number_fields = $stmt->columnCount();

        while ($row = $stmt->fetch())
        {
            echo "<tr>";
            for ($j = 0; $j < $number_fields; $j++) {
                    if ($row[$namecolumn[$j]])
                        echo("<td>" . $row[$namecolumn[$j]] . "</td>");
                    else
                        echo("<td>&nbsp;</td>");

            }
            echo "</tr>";
        }
        unset ($namecolumn);
        echo "</table><br />";
    }
}

catch(PDOException $e)
{
    die("Error: ".$e->getMessage());
}


function add_coment()
{
    if (isset($_REQUEST['send'])) {
        $name = $_REQUEST['name'];
        $city = $_REQUEST['city'];
        $email = $_REQUEST['email'];
        $url = $_REQUEST['url'];
        $msg = $_REQUEST['msg'];

        $date = date("Y-m-d H:i:s");

        try {
            $my_user = "root";
            $pass = "ariall83";
            $db = new PDO('mysql:host=localhost;dbname=my_guest_book', $my_user, $pass);

            $db->exec("insert into guest values(null,'$name', '$city', '$email', '$url', '$msg', '$date', 'show' 
                        ,null);");
        }
        catch (PDOException $e)
        {
            die("MyError: " . $e->getMessage());
        }
    }
}


?>