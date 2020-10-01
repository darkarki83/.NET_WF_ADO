<!DOCTYPE html>
<html lang="en" >
<head>
    <meta charset="utf-8" />
    <title>Simple HTML Document</title>
</head>
<body>
<?php
$nwords = array( "zero", "one", "two", "three", "four", "five", "six", "seven",
    "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen",
    "nineteen", "twenty", 30 => "thirty", 40 => "forty",
    50 => "fifty", 60 => "sixty", 70 => "seventy", 80 => "eighty",
    90 => "ninety" , "hundred" => "hundred", "thousand"=> "thousand", "million"=>"million",
    "separator"=>"and", "minus"=>"minus");


     $input = $_POST['text_1'];
     //$input = '-44552';
     if(!is_numeric($input)) {
         echo "wrong input";
         return;
     }
     $tmp = strlen($input);
     $arr = [];
     $coutstr = "";
     for ($i = 0 ; $i < $tmp ;$i++) {
         $arr[$i] = $input[$i];
     }
     if($arr[0] == '-') {
         $coutstr .= $nwords["minus"] . " ";
         \array_splice($arr, 0, 1);
     }

     if(count($arr) > 0) {
         while (count($arr) > 0) {
             if (count($arr) == 1) {

                 if ((int)$arr[0] == 0) {
                     if ($coutstr == "") {
                         $coutstr .= $nwords[0];
                     }

                     \array_splice($arr, 0, 1);
                     continue;
                 }

                 for ($i = 1; $i < 10; $i++) {
                     if ((int)$arr[0] == $i) {
                         $coutstr .= $nwords[$i];
                         \array_splice($arr, 0, 1);
                         break;
                     }
                 }
             } elseif (count($arr) == 2) {
                 if ((int)$arr[0] < 2) {
                     $tmpstr = (int)$arr[0] * 10 + (int)$arr[1];
                     //$tmpstr = implode ('', arr);
                     if ((int)$arr[0] == 0) {
                         \array_splice($arr, 0, 1);
                         continue;
                     }
                     for ($i = 1; $i < 10; $i++) {
                         if ($i + 10 == $tmpstr) {
                             $coutstr .= $nwords[$i + 10];
                             \array_splice($arr, 0, 2);
                             break(2);
                         }
                     }
                 } else {
                     for ($i = 2; $i <= 9; $i += 1) {
                         if ((int)$arr[0] == $i) {
                             $coutstr .= $nwords[$i * 10] . " ";
                             \array_splice($arr, 0, 1);
                             break;
                         }
                     }
                 }
             } elseif (count($arr) == 3) {
                 for ($i = 0; $i < 10; $i++) {
                     if ((int)$arr[0] == $i) {
                         $coutstr .= $nwords[$i] . " " . $nwords["hundred"] . " ";
                         \array_splice($arr, 0, 1);
                         break;
                     }
                 }
             } elseif (count($arr) == 4) {
                 for ($i = 0; $i < 10; $i++) {
                     if ((int)$arr[0] == $i) {
                         $coutstr .= $nwords[$i] . " " . $nwords["thousand"] . " ";
                         \array_splice($arr, 0, 1);
                         break;
                     }
                 }
             } elseif (count($arr) == 5) {
                 if ((int)$arr[0] < 2) {
                     $tmpstr = (int)$arr[0] * 10 + (int)$arr[1];
                     for ($i = 0; $i < 10; $i++) {
                         if ($i + 10 == $tmpstr) {
                             $coutstr .= $nwords[$i + 10] . " " . $nwords["thousand"] . " ";
                             \array_splice($arr, 0, 2);
                             break;
                         }
                     }
                 } else {
                     for ($i = 2; $i <= 9; $i += 1) {
                         if ((int)$arr[0] == $i) {
                             $coutstr .= $nwords[$i * 10] . " ";
                             \array_splice($arr, 0, 1);
                             break;
                         }
                     }
                 }
             }
         }
     }
    echo $coutstr;



/*}
else {
    echo 'Write only number';
}*/


?>


