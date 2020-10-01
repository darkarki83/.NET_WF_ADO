<?php
$books = array ("php" =>
                "PHP users guide",
                12 => true);
echo $books["php"];
echo "<br>";

//выведет "PHP users guide"
echo $books[12];     //выведет 1
echo "<br>";

$arr = array(5 => 43, 32, 56, "b" => 12,50);
print_r($arr);

$books["key"]= 10; // добавили в массив
                    // $books значение
                    // 10 с ключом key
$books[] = 20; /* добавили в массив
                      значение value1 с
                      ключом 13, поскольку
                      максимальный ключ у
                      нас был 12 */
echo $books[13];
?>