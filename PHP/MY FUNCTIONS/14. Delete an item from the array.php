<?php
$books = array ("php" =>
                "PHP users guide",
                12 => true);

$books[] =
 "Book about Perl"; // добавили элемент
                    // с ключом (индексом)
                    // 13 это эквивалентно
                    // $books[13] =
                    // "Book about Perl";
$books["python"] =
 123456; /* Это добавляет к массиву новый
            элемент с ключом "python" и
            значением 123456 */

echo $books[13];  // выведет    Book about Perl

unset($books[12]); // Это удаляет элемент
                   // c ключом 12 из массива
unset ($books); // удаляет массив полностью

echo $books[13];    // ничего не выведет
?>