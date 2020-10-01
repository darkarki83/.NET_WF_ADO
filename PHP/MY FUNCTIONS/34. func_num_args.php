<?php

function DataPrint()
{
  $n = func_num_args();
  // число аргументов,
  // переданных в функцию

  $args = func_get_args();
  // массив аргументов функции
  for ($i=0;$i<$n;$i++){
    echo $args[$i]."<br>";
  }
	echo "<br>";
}
DataPrint("text", 324);
DataPrint(324, 10, 20, "!!!", 5.7);
?>