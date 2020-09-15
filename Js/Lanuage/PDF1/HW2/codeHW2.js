"use strict"

let HW2 = function(){
    let flag = false;
    do {
    let number = 0;
    do{
    number = prompt("Write traleibus number", "123456");
    }while(!checkNumber(number))
   
    let temp = parseInt(number);
    let first = 0;
    let second = 0;
    for(let i = 0; i < 3; i++) {
        first += temp % 10;
        temp = parseInt(temp / 10);
    }
    for(let i = 0; i < 3; i++) {
        second += temp % 10;
        temp = parseInt(temp / 10);
    }
    alert(first == second?"It is happy  number":"It is not happy  number");
    flag = confirm("Do you want continium ?");
    }while(flag)
}

function checkNumber(number) {
    // Создаем рег.выражение, определяющие номер телефона с кодом
    const r = /\b\d{6}\b/;

    // Метод test просто проверяет подпадает или нет строка под регулярное выражение.
    // Т.е., он возвращает true или false.
    if (r.test(number))
        return true;
    else {
        alert("wrong input try again");
        return false;
    }
}