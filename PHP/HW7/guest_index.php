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

        $j = 0;
        while($row = $sth->fetch())
        {
            if($j != 3) {
                $namecolumn[] = $row[0];
                echo "<th>" . $row[0] . "</th>";
            }
            $j++;
        }

        echo "</tr></thead>";
        $query = "SELECT * FROM " . $nametable[$i];
        $stmt = $db->query($query);
        $number_fields = $stmt->columnCount() - 1;

        while ($row = $stmt->fetch())
        {
            echo "<tr>";
            for ($j = 0; $j < $number_fields; $j++) {
               // if ($j != 3) {
                    if ($row[$namecolumn[$j]])
                        echo("<td>" . $row[$namecolumn[$j]] . "</td>");
                    else
                        echo("<td>&nbsp;</td>");

                //}
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









?>