"use strict"

function HW4() 
{
    
    let answer = [2,3,2,4,2];

    let qoution = [];

    qoution.push(`Какие цвета образуют французский флаг?\n 1) синий, белый, красный\n 2) синий, белый и красный\n 3) Синий, белый, красный\n 4) Синий, белый и красный`);
    qoution.push(`What is blue, or red, or yellow?\n 1) a colour\n 2) a color\n 3) it's a colour\n 4) it's a color`);
    qoution.push(`Столица Англии?\n 1) АдиссАбеба\n 2) Лондон \n 3) Будапешт\n 4) Минск`);
    qoution.push(`Какая самая большая страна в мире?\n 1) Сша\n 2) Казахстан\n 3) Канада\n 4) Россия`);
    qoution.push(`Из скольки главных островов состоит Япония?\n 1) 1-2 острова\n 2) 2-4 острова\n 3) 3- 5 островов\n 4) 4-7 островов`);

    let result = 0;

    qoution.forEach((item) => console.log(item)); // на посмотреть

    for(let i = 0; i < qoution.length; i++) {
        let ans = 0;
        let flag = false;
        do {
        ans = parseInt(prompt(qoution[i], `1`));
        flag = checkNumber(ans);
        }while(!flag)

        if(answer[i] == ans) {
            result += 20;
        }
    }

    alert(` your result is = ${result}`);
}

function checkNumber(number) {
    // Создаем рег.выражение, определяющие номер телефона с кодом
    const r = /\b[1-4]{1}\b/;

    // Метод test просто проверяет подпадает или нет строка под регулярное выражение.
    // Т.е., он возвращает true или false.
    if (r.test(number))
        return true;
    else {
        alert("wrong input try again");
        return false;
    }
}
