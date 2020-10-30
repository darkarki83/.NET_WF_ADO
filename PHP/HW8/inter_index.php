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
<form action="" method="post">
    <table style="margin: 50px">
        <tr style="font-size: 20px; text-align: center" >
            <td colspan="2"><label> Our coach</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="1" checked></td>
            <td><label>Oleg Blohin</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="2"></td>
            <td><label>Uri Kaletvinjev</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="3"></td>
            <td><label>Mircha Lechesku</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="4"></td>
            <td><label>Miron Markevich</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="5"></td>
            <td><label>Alexei Mihailichenko</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="6"></td>
            <td><label>Pavel Iakovenko</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="7"></td>
            <td><label>Another domestic coach</label></td>
        </tr>
        <tr>
            <td><input type="radio" name="foot" value="8"></td>
            <td><label>Foreign coach</label></td>
        </tr>
        <tr>
            <td style="text-align: center" colspan="2"><input style="width: 100px" type="submit"
                                                                            name="send"
                                                                             value="send"></td>
        </tr>
    </table>
</form>
</body>
</html>

<?php
Vote();

try {

    $my_user = "root";
    $pass = "ariall83";
    $db = new PDO('mysql:host=localhost;dbname=internet_vote', $my_user, $pass);



    $tables = $db->query('SHOW TABLES');
    while ($row = $tables->fetch()) {

        $nametable[] = $row[0];
    }

    $n = count($nametable);
    for ($i = 0; $i < $n; $i++)
    {
        echo "<table style='border-color: #f57b93' border='1' width='50% >";
        echo "<caption style = 'font-size:20pt;font-weight:bold;color:red'>".$nametable[$i]."</caption>";
        echo "<thead><tr>";
        $q = "SHOW COLUMNS FROM ". $nametable[$i];  // отдал названия и тип столбца
        $sth = $db->query($q);
        $index = 0;

        while($row = $sth->fetch())
        {
            if($index > 0) {
                $namecolumn[] = $row[0];
                echo "<th>" . $row[0] . "</th>";
            }
            $index++;
        }

        echo "</tr></thead>";
        $query = "SELECT * FROM " . $nametable[$i];
        $stmt = $db->query($query);
        $number_fields = $stmt->columnCount();

        while ($row = $stmt->fetch())
        {
            echo "<tr>";
            for ($j = 0; $j < $number_fields - 1; $j++) {
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

function Vote() {
    if(isset($_REQUEST['send'])) {

        $last_count = 0;

        $link = mysqli_connect("127.0.0.1", "root", "ariall83", "internet_vote");

        if (!$link) {
            echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
            exit;
        }

        $query = "select vote.votes_count from vote where id = " .
            $_REQUEST['foot']. ";";

        if($result = mysqli_query($link, $query))
        {
            while ($row=$result->fetch_row()) {
                for ($i = 0; $i < count($row); $i++)
                    $last_count =  $row[$i];
            }
            $result->close();
        }
        mysqli_close($link);

        $new_one = (int)$last_count + 1;
        try{
            $user = "root";
            $pass = "ariall83";
            $db= new PDO('mysql:host=localhost;dbname=internet_vote', $user, $pass);

            $str = "update vote set votes_count = " . "$new_one" .  " where id = " . $_REQUEST['foot'] . ";";
            $db->exec($str);

        }
        catch (PDOException $e) {
            die("Error :" . $e->getMessage());
        }
    }
}








?>
