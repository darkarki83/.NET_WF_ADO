"use strict"

/*Задание 1
Реализовать класс ExtendedDate, унаследовав его от стандартного класса Date и добавив следующие возможности:
 метод для вывода даты (числа и месяца) текстом;
 метод для проверки – это прошедшая дата или будущая (если прошедшая, то метод возвращает false; если будущая или текущая, то true);
 метод для проверки – високосный год или нет;
 метод, возвращающий следующую дату.
Создать объект класса ExtendedDate и вывести на экран результаты работы новых методов. */

let months = ["Января", "Февраля", "Марта", "Апреля", "Мая", "Июня", "Июля", "Августа", "Сентября", "Октября", "Ноября", "Декабря"];
let days = ["первое", "второе", "третье", "четвертое", "пятое", "шестое", "седьмое", "восьмое", "девятое", "десятое", "одиннадцатое", "двенадцатое", "тринадцатое", "четырнадцатое", "пятнадцатое", "шестнадцатое", "семнадцатое", "восемнадцатое", "девятнадцатое", "двадцатое", "двадцат первое", "двадцать второе",  "двадцать третье",  "двадцать четвертое", "двадцать пятое", "двадцать шестое", "двадцать седьмое", "двадцать восьмое", "двадцать девятое", "тридцатое", "тридцать первое"];

class ExtendedDate extends Date {

    myMonths;

    constructor() {
        super();
        this.myMonths = this.getMonth
    }

    dayAndMonthStr() {
        document.write(`${days[this.getDate()- 1]} <br>`);
        document.write(`${months[this.getMonth()]} <br>`);

        console.log(months[this.getMonth()]);
        console.log(days[this.getDate()- 1]);
    }

    static compare(yourDate, todayDate) {
        if(todayDate.getFullYear() -  yourDate.getFullYear() > 0) {
            return false;
        }
        else if(todayDate.getFullYear() -  yourDate.getFullYear() < 0) {
            return true;
        }
        else if(todayDate.getFullYear() -  yourDate.getFullYear() == 0) {
            if(todayDate.getMonth() -  (yourDate.getMonth() - 1)  > 0) {
                return false;
            }
            else if(todayDate.getMonth() -  (yourDate.getMonth() - 1) < 0) {
                return true;
            }
            else if(todayDate.getMonth() -  (yourDate.getMonth() - 1) == 0) {
                if(todayDate.getDate() -  yourDate.getDate() > 0) {
                    return false;
                }
                else if(todayDate.getDate() -  yourDate.getDate() < 0) {
                    return true;
                }
                else if(todayDate.getDate() -  yourDate.getDate() == 0) {
                    return true;
                }
            }
        }
    }

    isFuture() {
        let inputDate;
        
        do {
            inputDate = prompt("Input Date : ","0000, 00, 00");
            inputDate = inputDate.trim();
        }while(!ExtendedDate.CheckInut01(inputDate))
        let a = inputDate.split(",");
        let yourDate = new Date(parseInt(a[0]), parseInt(a[1]), parseInt(a[2]));
        return ExtendedDate.compare(yourDate, this);
    }

    isLeapYear() {
        let flag = false;
        let inputDate;
        do {
        inputDate = prompt("Input Year : ", "0000");
        } while(!ExtendedDate.CheckInput(inputDate))

        if(parseInt(inputDate) % 4 == 0) {
            return true;
        }
        else {
            return false;
        }
    }
    static CheckInut01(text) {

        const r = /\d{4}\,?\d{2}\,?\d{2}/;

        if(r.test(text)) {
            return true;
        }
        else {
            alert("wrong input try again");
            return false;
        }
    }

    static CheckInut(text) {

        const r = /\b\d{4}\b/;

        if(r.test(text)) {
            return true;
        }
        else {
            alert("wrong input try again");
            return false;
        }
    }

    nextDate() {
        return new Date(this.getFullYear(), this.getMonth(), this.getDate() + 1);
    }
}

