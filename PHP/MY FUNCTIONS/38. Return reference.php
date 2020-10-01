<?php

$a = 3; 
$var = & ref();
echo $var, " и ", $a,"<br>";
   //выведет 3 и 3
$a = 10;
echo $var, " и ", $a,"<br>";
   // выведет 10 и 10
   
function & ref()
{
	global $a;
	return $a;
}

?>