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
            <td colspan="2"><label> Choice Hotel</label></td>
        </tr>
        <tr>
            <td colspan="2">
                <select name="hotels" style="width: 50%">
                   <?php
                   Hotels();
                   ?>
                </select>
            </td>
        </tr>
        <tr >
            <td colspan="2" style="height: 30px">
            </td>
        </tr>
        <tr >
            <td colspan="2" >
               <label> add your comment</label>
            </td>
        </tr>

        <tr>
            <td colspan="2">
                <textarea rows="10" cols="50" name="about" value=""></textarea>
            </td>
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
add_commint();

function add_commint() {
    if(isset($_REQUEST['send'])) {

        $comment = $_REQUEST['about'];
        $town = $_REQUEST['hotels'];

        echo $comment . "<br >";
        echo $town;

        try{
            $user = "root";
            $pass = "ariall83";
            $db= new PDO('mysql:host=localhost;dbname=hotel_comments', $user, $pass);

            $str = "insert into commets value(null, '$comment', '$town') ;";
            $db->exec($str);

        }
        catch (PDOException $e) {
            die("Error :" . $e->getMessage());
        }



    }
}

function Hotels() {

    $link = mysqli_connect("127.0.0.1", "root", "ariall83", "hotel_comments");

    if (!$link) {
        echo "Ошибка: Невозможно установить соединение с MySQL." . PHP_EOL;
        exit;
    }

    $query = "select hotels.id, hotels.name from hotels;";

    if ($result = mysqli_query($link, $query)) {

        while ($row = $result->fetch_row()) {
            //for ($i = 0; $i < count($row); $i++)
                echo "<option value='$row[0]'>$row[1]</option>";
        }
        $result->close();
    }
    mysqli_close($link);
}
?>
