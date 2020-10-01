"use strict"

$(document).ready( function () {

    let counter = 0;
    let testerName;
    let span = $("span");
    let result = 0;
    let checkboxs = $('input[type$="checkbox"]');
    let flagConecting = false;
    for (const checkbox of checkboxs) {
        console.log(checkbox);
    }
    let idTimer;

    getFroumCookie();

    loadQuation(); //  подгрузил первый вопрос

    $('input[name$="answer"]').bind('click', function (event) {  //обработчик перехода на сед вопрос

        CalResult(counter);

        timer = 30;                      // перегрузка таймера
        $("span")[5].innerHTML = timer;  // перересовка таймера

        if(counter <  ArrAnsQua.length)
            loadQuation();             // след. опрос
        else
            counter++;                // чтобы последний раз праверить ответы

        if(counter == 5) {
            clearInterval(idTimer);    // выключаю таймер

            $("form#one").css("visibility", "hidden");  // выключаю форму вопроов
            $("form#one").css("height", "0");

            $("form#two").css("visibility", "visible"); // включаю формы Cookie
            $("span")[6].innerHTML = "Your result :"
            $("span")[7].innerHTML = result;
            $("span")[8].innerHTML = "";
            $('input[name$="name"]')[0].value = testerName;
            $('input[name$="name"]')[0].readOnly = true;
            saveCookie();
        }
    });

    $('input[name$="gotest"]').bind('click', function (event) {
        testerName = $('input[name$="name"]')[0].value;

        if(!flagConecting && testerName.length > 3) {
            idTimer = setInterval("ShowQ()", 1000);
            console.log(testerName);
            $("form#two").css("visibility", "hidden");
            $("form#one").css("visibility", "visible");
            $("form#one").css("height", "auto");
            flagConecting = true;
        }
    });

    function getFroumCookie() {
        let str;
        let num = 0;
        if(document.cookie != 0) {    //если есть cookie
            str = document.cookie;
            let arr = str.split(";");
            for (const item of arr) {
                if("name" == item.split('=')[0].trim()) {
                    $("span")[8].innerHTML = "Your name :";
                    $('input[name$="name"]')[0].value = item.split('=')[1];
                    $('input[name$="name"]').prop('readonly', true);
                    num++;
                }
                if("result" == item.split('=')[0].trim()) {
                    $("span")[6].innerText = "Your last Result : "
                    $("span")[7].innerText = item.split('=')[1]
                    num++;
                }
            }
        }
        if(num == 2) {
            console.log($('input[name$="gotest"]'));
            $('input[name$="gotest"]')[0].value = 'Go Again';
        }
        else {
            $("span")[6].value = "";
            $("span")[7].value = "";
        }
    }

    function loadQuation() {                           // подгрузка вопроса по i
        span[0].innerHTML = (ArrAnsQua[counter].quation);
        //$("span")[1].text(ArrAnsQua[0].first);  /// no work way!!!!
        $("span")[1].innerHTML = ArrAnsQua[counter].first;
        $("span")[2].innerHTML = ArrAnsQua[counter].second;
        $("span")[3].innerHTML = ArrAnsQua[counter].thert;
        $("span")[4].innerHTML = ArrAnsQua[counter].four;
        counter++;
    }

    function saveCookie() {
        let d = new Date();
        d.setMonth(d.getMonth() + 6);
        document.cookie = "name=" + $('input[name$="name"]')[0].value + ";path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "result=" + result + ";ath=/;expires=" + d.toUTCString() + ";";
        flagConecting = false;

    }
    function CalResult(counter) {   // проверка правельно ли человек ответил
        // сложная чтобы зацита от взлома(я папытался)
        // не всегда отрабатует правельно
        if (checkboxs[0].checked) { //
            checkboxs[0].checked = false;
            if (ArrAns[counter - 1].f == 10 + counter) {
                result = result + 100 / 8;
            }
        }
        if (checkboxs[1].checked) {
            checkboxs[1].checked = false;
            if (ArrAns[counter - 1].s == 10 + counter) {
                result = result + 100 / 8;
            }
        }
        if (checkboxs[2].checked) {
            checkboxs[2].checked = false;
            if (ArrAns[counter - 1].t == 10 + counter) {
                result = result + 100 / 8;
            }
        }
        if (checkboxs[3].checked) {
            checkboxs[3].checked = false;
            if (ArrAns[counter - 1].fo == 10 + counter) {
                result = result + 100 / 8;
            }
        }
    }

})

let span = $("span");
let timer = 30;

function ShowQ() {
    timer--;
    $("span")[5].innerHTML = timer;
    if(timer == 0) {
        timer = 30;
        $('input[name$="answer"]').click();
    }
}
window.jQuery = window.$ = jQuery