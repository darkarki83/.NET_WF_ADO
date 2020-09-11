"use strict"

let FotoAraay = ["img/0.gif", "img/1.gif", "img/2.gif", "img/3.gif", "img/4.gif", "img/5.gif", "img/6.gif", "img/7.gif", "img/8.gif", "img/9.gif"];
let DaysOfWeek = new Array("Воскресенье", "Понедельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота");

function MyClock()  {

    let theDate = new Date();

    let hour = theDate.getHours();
    let min = theDate.getMinutes();
    let sec = theDate.getSeconds();

    let dev;

    if(hour < 10) {
        hour1.src = FotoAraay[0];
        hour2.src = FotoAraay[hour];
    }
    else {
        dev = parseInt(hour / 10);
        hour1.src = FotoAraay[dev];
        hour2.src = FotoAraay[hour - dev * 10];
    }
    if(min < 10) {
        min1.src = FotoAraay[0];
        min2.src = FotoAraay[min];
    }
    else {
        dev = parseInt(min / 10);
        min1.src = FotoAraay[dev];
        min2.src = FotoAraay[min - dev * 10];
    }
    if(sec < 10) {
        sec1.src = FotoAraay[0];
        sec2.src = FotoAraay[sec];
    }
    else {
        dev = parseInt(sec / 10);
        sec1.src = FotoAraay[dev];
        sec2.src = FotoAraay[sec - dev * 10];
    }

    let dayofWeek = theDate.getDay();
    dayHTML.innerText = DaysOfWeek[dayofWeek];

    let day = theDate.getDate();
    console.log(day);
    daySpan.innerText = day;

    let month = theDate.getUTCMonth() + 1;
    console.log(month);
    monthSpan.innerText = month;

    let year = theDate.getUTCFullYear();
    console.log(year);
    yearSpan.innerText = year;

}