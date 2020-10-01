<html>
<head>
</head>
<body bgcolor="#aab7ab">
<h2> Результат:</h2>
<p>
<?php

$num1 = $_REQUEST["num1"];
$num2 = $_REQUEST["num2"];

if(is_numeric($num1) && is_numeric($num1)) {
    if(isset($_REQUEST["operation"])) {
        $radio = $_REQUEST["operation"];
        if ($radio == "plus") {
            echo $num1 + $num2;
        } elseif ($radio == "minus") {
            echo $num1 - $num2;
        } elseif ($radio == "multiply") {
            echo $num1 * $num2;
        } elseif ($radio == "divide") {
            if ($num2 == 0) {
                echo "do you now divide 0 dont inposible ";
            } else {
                echo $num1 / $num2;
            }

        }
    }
}
else {
    echo "wrong input ";
}


?>
    </p>
</body>
</html>

