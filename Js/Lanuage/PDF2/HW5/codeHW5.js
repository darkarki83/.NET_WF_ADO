"use strict"

function HW5() 
{
    let flag = true;
    
    while(flag) {
        let name = prompt(`Get name father name and surname ?`, `Ivan ivanich ivanov`);

        if(!checkNumber(name)) {
            continue;
        }

        let a = name.split(" ");

        alert(`Your name : ${a[0]} \nYour father name : ${a[1]} \nYour surename : ${a[2]}`)
        flag = confirm(`you wont play again?`)
    }
}

function checkNumber(name) {
    // Создаем рег.выражение, определяющие номер телефона с кодом
    const r = /^[a-zA-Z\ \.]+$/;

    // Метод test просто проверяет подпадает или нет строка под регулярное выражение.
    // Т.е., он возвращает true или false.
    if (r.test(name)) {
        return true;
    }
    else {
        alert("wrong input try again");
        return false;
    }
}
