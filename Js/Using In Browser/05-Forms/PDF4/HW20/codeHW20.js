"use strict"

$(document).ready ( function () {

    let email = $('input[name$="email"]');
    let sign = $('input[name$="sign"]');
    let pass1 = $('input[name$="pass1"]');
    let pass2 = $('input[name$="pass2"]');

    console.log(email);

    $('input[name$="email"]').bind('change', function(e) {

        console.log(email[0].value);

        if(!checkeMail(email[0].value)) {
            console.log("add help");
        }
    })

    $('input[name$="sign"]').bind('click', function(e) {

        if(!checkeMail(email.value)) {
            return false;
        }
    })

    pass1.bind('change', function (e) {

        if(!checkPass1(pass1.value)) {
            console.log("add help");
        }
    })

    $('input[name$="sign"]').bind('click', function(e) {

        if (!checkPass1(pass1.value)) {
            return false;
        }
    })

});

function checkeMail(text) {

    const email = /((^[A-z._]\w{3,15})\@([A-z.]+\.))([A-z]{2,3})$/;

    return email.test(text) ? true : false;
}

function checkPass1(text) {

    const pass1 = /([A-Z]{1,}[a-z]{1,}[0-9]{1,}){6, }/;

    return pass1.test(text) ? true : false;
}
window.jQuery = window.$ = jQuery