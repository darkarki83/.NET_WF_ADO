"use strict"

$("#client")[0].innerText = "Hi " + clientMail;

let inputs = $("#table2").find("input");
inputs.css('width', '240px');

let save = $('input[name$="save"]');
save.css('width', '96%');

$('select[name$="gender"]').css('width', '240px');  // чтобы не праписывать в css
$("body").css('background-color', 'grey');

$("a").bind('click', function (e) {

    localStorage.removeItem("email");
    localStorage.removeItem("password");
    $("a")[0].click;
})

save.bind('click', function () {

    if (!checkeName(inputs[0].value)) {
        return false;
    }
    if (!checkeName(inputs[1].value)) {
        return false;
    }
    /*if (inputs[4].value.length > 0) {
        if (!checkePhone(inputs[4].value)) {
            return false;
        }
    }*/

    localStorage.setItem("firstName", $('input[name$="firstName"]').val());
    localStorage.setItem("lastName", $('input[name$="lastName"]').val());
    localStorage.setItem("date", $('input[name$="year"]').val());
    localStorage.setItem("gender", $('select').val());

    if($('input[name$="phone"]').val().length > 0) {
        localStorage.setItem("tel", $('input[name$="phone"]').val());
    }

    if($('input[name$="skype"]').val().length > 0) {
        localStorage.setItem("skype", $('input[name$="skype"]').val());
    }

    $("#sform").css('visibility', 'hidden').css("height", 0);
    $("#bye").css('visibility', 'visible');
})

function checkeName(text) {

    const name = /^([A-z]+){1,20}$/;

    return name.test(text) ? true : false;
}
function checkePhone(text) {

    const name = /(^((\+\d{4,5})\-)|([0]{1}\d{2}))\-(\d{3})\-(\d{4})$/;

    return name.test(text) ? true : false;
}