"use strict"

/*Создать html-страницу для ввода имени пользователя. Необходимо проверять каждый символ, который вводит пользователь.
Если он нажал на цифру, то не отображать ее в текстовом поле.*/

let mytext= document.getElementById("mytext");

function inputText(event) {
    let s = event.key;

    if(!checkSign(s)) event.preventDefault();
}

function checkSign(s) {
    const r = /\D/;

    return r.test(s)
}