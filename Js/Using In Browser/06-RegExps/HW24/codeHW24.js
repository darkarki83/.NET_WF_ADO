"use strict"

let textFild = document.getElementById("textFild");

function checkName() {
    // Создаем рег.выражение, определяющие номер телефона с кодом
    let txt = textFild.value;
    console.log(txt);

    const r = /[A-zА-яЁё]\ (([A-zА-яЁё]{1})[.]?([A-zА-яЁё]{1})[.]?)$/;

    const email = /((^[A-z]\w{2,15})\@([A-z.]+\.))([A-z]{2,3})$/;

    const date = /\d{2}[-]+\d{2}[-]+(\d{4})+$/;
    // Метод test просто проверяет подпадает или нет строка под регулярное выражение.
    // Т.е., он возвращает true или false.
    alert(r.test(txt)?"good name!":"no good name!");
}