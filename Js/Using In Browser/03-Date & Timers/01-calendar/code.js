"use strict"
/*Написать клиентский сценарий, который отображает календарь на текущий месяц.*/

let choiceDate = prompt("Get your Date : ", "2015, 9, 10");
let DaysOfWeek = new Array("Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота");
let Foto = new Array("seasons/1.JPG", "seasons/2.JPG", "seasons/3.JPG", "seasons/4.JPG");

let OurDate = new Date(choiceDate);  // create date
let month = OurDate.getMonth();
let day = OurDate.getDate();

OurDate.setDate(1);
let dayWeek = OurDate.getDay();

let flag = true;
let foto = 0;
if(month > 1 && month < 5){
    foto = 1;
} else if(month > 4 && month < 8){
    foto = 2;
} else if(month > 7 && month < 11){
    foto = 3;
} else if(month > 10 && month < 2){
    foto = 0;
}

document.write(`<table style="background-image: url(${Foto[foto]});">`);
    for (let i = 0; i < 7; i++) {
        document.write(`<tr>`);
        for (let j = 0; j < 7; j++) {
            if (i == 0) {
                document.write(`<td style="font-size: 20px; color: #3300AA"> ${DaysOfWeek[j]} </td> `);
            } else if (i == 1) {
                if(j >= dayWeek) {
                    if(OurDate.getDate() == day) {
                        document.write(`<td style="font-size: 20px; color: red"> <span style="border-width: medium; border-style: double; border-color: #6633FF"> ${OurDate.getDate()} </span></td>`);
                    }
                    else {
                        document.write(`<td style="font-size: 20px; color: red">  ${OurDate.getDate()}</td>`);
                    }
                    OurDate.setDate(OurDate.getDate() + 1);
                }
                else
                {
                    if(flag == true) {
                        OurDate.setDate(OurDate.getDate() - dayWeek);
                        flag = false;
                    }
                    document.write(`<td style="font-size: 20px; color: gray"> ${OurDate.getDate()} </td>`);
                    OurDate.setDate(OurDate.getDate() + 1);
                }
            } else {
                if(OurDate.getMonth() == month) {
                    if(OurDate.getDate() == day) {
                        document.write(`<td style="font-size: 20px; color: red"> <span style="border-width: medium; border-style: double; border-color: #6633FF"> ${OurDate.getDate()} </span></td>`);
                    }
                    else {
                        document.write(`<td style="font-size: 20px; color: red">  ${OurDate.getDate()}</td>`);
                    }
                    OurDate.setDate(OurDate.getDate() + 1);
                }
                else {
                    document.write(`<td style="font-size: 20px; color: gray"> ${OurDate.getDate()} </td>`);
                    OurDate.setDate(OurDate.getDate() + 1);
                }
            }
        }
        document.write(`</tr>`);
        if(OurDate.getMonth() != month)
            break;
    }
    document.write(`</table>`);


