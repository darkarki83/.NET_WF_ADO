<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <style>
        #grid {
            display: grid;
            height:200px;
            grid-template-rows: 15% 40% 40%;
            grid-template-columns: 80%;
            grid-gap: 5%;
            background-color: crimson;
        }

        #l0 {
            margin-left: 10%;
            text-align: center;
        }

        #l4 {
            width: 90%;
            height: 50%;
            margin-left: 10%;
            text-align: center;
            background-color: rebeccapurple;
        }

        #l1 {
            margin-left: 10%;
            display: grid;
            grid-template-columns: 40% 60%;
            grid-template-rows: 50%;
        }

    </style>
</head>
<body>
<form id="grid" action="" method="post">
    <div id="l0">
        <label> //\\// Country //\\//</label>
    </div>
    <div id="l1">
        <label style="margin-top: 10px" >Add New Country :</label>
        <input type="text" name="country" placeholder="Country name :" required/>
    </div>
    <input id="l4" type="submit"  name="add" value="Add" />
</form>
</body>
</html>



<?php

if(isset($_REQUEST['add'])) {

    addSelect();

    if(isCorectCountry() && isNeedSave()) {

        addToFile();
       // addSelect();
    }
}

function addSelect() {

    echo '<select name="countres" id="count" style="width: 50%">';

    $file = fopen('country.txt', 'r+') or die ('can not open file');

    while (!feof($file)) {

        $str = htmlentities(fgets($file));

        $str = explode(' ', $str);

        foreach ($str as $value) {
            if(strlen($value) > 0) {
                echo "<option value=" . $value . ">" . $value . "</option>";
            }
        }
    }
}

function isCorectCountry() {

    $diction = fopen('dictionary.txt', 'r+') or die ('can not open file');
    $cor = false;

    while (!feof($diction)) {

        $str = htmlentities(fgets($diction));

        $str = explode(' ', $str);

        foreach ($str as $value) {
            if($value == $_REQUEST['country']) {
                $cor = true;
                break;
            }
        }
    }
    fclose($diction);
    if(!$cor) echo "Not corect input Country";
    return $cor;
}

function isNeedSave()
{
    $file = fopen('country.txt', 'r+') or die ('can not open file');

    while (!feof($file)) {

        $str = htmlentities(fgets($file));

        $str = explode(' ', $str);

        foreach ($str as $value) {
            if ($value == $_REQUEST['country']) {
                fclose($file);
                echo "We have this Country in File";
                return false;
            }
        }
    }
    fclose($file);
    return true;
}

function addToFile() {
    $file = fopen('country.txt' , 'a');
    fwrite($file, $_REQUEST['country'] . ' ');
    fclose($file);
}






?>
