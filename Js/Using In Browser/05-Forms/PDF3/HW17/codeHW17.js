"use strict"

$(document).ready( function () {

    $("#ready").bind("click", ClickReady);

    console.log($('input[name$="radio_gender"]'));

    for (const item of $('input[name$="radio_gender"]')) {
        console.log(item.checked);
    }

    console.log($('input[type$="checkbox"]'));

    for (const checkb of $('input[type$="checkbox"]')) {
        console.log(checkb);
    }

    console.log($('select[name$="list_work"]')[0]);

    for (const options of $('select[name$="list_work"]')[0]) {
        console.log(options);
    }

    for (const options of $('select[name$="list_work"]')[0]) {
        console.log(options.selected);
    }

    console.log($('input[name$="e_mail"]'));

    let ele = $('#form');/*Your Form Element*/
    ele.bind("submit", newWindow);

    function ClickReady(event) {

        //let str = location.href;
        //console.log(str);
        //console.log(event.target);
        //console.log($("#password1")[0]);
        //console.log($("#password2")[0]);
        //let aaaa = $("#password1")[0];
        ///console.log($("#password1")[0].value);

        if ($("#password1")[0].value < 3) {
            alert("password wery short !!! try again ");
            return false;
        } else if ($("#password1")[0].value != $("#password2")[0].value) {
            alert("confirm not matches password : try again");
            return false;
        }

        AddCookie();
        //console.log($("#password2").text());
        return true;
        //if($("password1").)
    }

    function AddCookie() {
        let d = new Date();
        d.setMonth(d.getMonth() + 6);

        let looklogin = $("#login")[0].value;
        console.log(looklogin);
        console.log($('input[name$="login"]').value);
        document.cookie = "login=" + $("#login")[0].value + ";path=/;expires=" + d.toUTCString()+ ";";


    }

    function newWindow(event) {

        let str = location.href;  // work
        console.log(str);
    }





























})


window.jQuery = window.$ = jQuery