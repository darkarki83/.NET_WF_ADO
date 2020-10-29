<?php

manage_mode();

function manage_mode(){

    Add();
    Delete();

    try {

        $my_user = "root";
        $pass = "ariall83";
        $db = new PDO('mysql:host=localhost;dbname=my_guest_book', $my_user, $pass);



        $tables = $db->query('SHOW TABLES');
        while ($row = $tables->fetch()) {

            $nametable[] = $row[0];
        }

        $n = count($nametable);
        for ($i = 0; $i < 1; $i++)
        {

            echo "<form action=' '  method='post'>";
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
            $row_count = 0;
            $id = 1;
            while ($row = $stmt->fetch())
            {
                $row_count++;
                echo "<tr>";
                for ($j = 0; $j < $number_fields; $j++) {

                    if($j == $number_fields - 1){
                        echo("<td>" . "<input type='text' name='ans$id'  >" . "</td>");
                    }
                    else if ($row[$namecolumn[$j]]) {
                        if ($j == 0) {
                            $id = (int)$row[$namecolumn[$j]];
                        }
                        echo("<td>" . $row[$namecolumn[$j]] . "</td>");
                    }
                    else
                        echo("<td>&nbsp;</td>");

                }

                echo "<td>" . "<input id='add$id' name='add' type='submit' value='Add $id'  />" . "</td>";
                echo "<td>" . "<input id='del$id' name='del' type='submit' value='Delete $id' />" . "</td>";
                echo "<td>";
                if($row["hide"] == 'show')
                {
                    echo "<input id='enum$id' name='enum' class='$id' type='submit' value='hide' />". "</td>";
                }
                else
                {
                    echo "<input id='enum$id' name='enum' class='$id' type='submit' value='show' />" . "</td>";
                }
                echo "</tr>";
            }
            unset ($namecolumn);
            echo "</table><br />";
            echo "</form>";
        }
    }
    catch(PDOException $e)
    {
        die("Error: ".$e->getMessage());
    }
}

function Add() {

    if (isset($_REQUEST['add'])) {
        $id = $_REQUEST['add'];
        $num = '0';
        $num = explode(' ', $id)[1];


        try {
            $my_user = "root";
            $pass = "ariall83";
            $db = new PDO('mysql:host=localhost;dbname=my_guest_book', $my_user, $pass);

            $tables = $db->query('SHOW TABLES');

            while ($row = $tables->fetch()) {

                $nametable[] = $row[0];
            }

            $val = $_REQUEST["ans$num"];

            $str = "update guest set answer = " . "'$val'" .  " where id_msg = " . $num . ";";

            echo $str;

            $db->exec($str);

        } catch (PDOException $e) {
            die("Error: " . $e->getMessage());
        }
    }

}

function Delete() {

    if (isset($_REQUEST['del'])) {
        $id = $_REQUEST['del'];
        $num = '0';
        $num = explode(' ', $id)[1];


        try {
            $my_user = "root";
            $pass = "ariall83";
            $db = new PDO('mysql:host=localhost;dbname=my_guest_book', $my_user, $pass);

            $tables = $db->query('SHOW TABLES');

            while ($row = $tables->fetch()) {

                $nametable[] = $row[0];
            }

            echo $num;
            $str = "delete from guest where id_msg = " . $num . ";";
            $db->exec($str);

        } catch (PDOException $e) {
            die("Error: " . $e->getMessage());
        }
    }
}








?>
