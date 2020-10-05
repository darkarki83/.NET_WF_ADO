"use strict"

$(document).ready ( function () {

    let email = $('input[name$="email"]');
    let sign = $('input[name$="sign"]');
    let pass1 = $('input[name$="pass1"]');
    let pass2 = $('input[name$="pass2"]');

    //console.log(email);

    $('input[name$="sign"]').bind('click', function(e) {

        if(!checkeMail(email[0].value)) {
            return false;
        }
        if(!checkPass1(pass1[0].value)) {
            return false;
        }
        if(pass1[0].value != pass2[0].value) {
            return false;
        }
        saveLocal();

        location.href=`index2.html`;
        return true;
    })

    $('input[name$="email"]').bind('change', function(e) {
        if(!checkeMail(email[0].value)) {
            $("#gridItem3").css('visibility', 'visible');
        }
        else {
            $("#gridItem3").css('visibility', 'hidden');
        }
    })

    pass1.bind('change', function (e) {

        if(!checkPass1(pass1[0].value)) {
            $("#gridItem6").css('visibility', 'visible');
        }
        else {
            $("#gridItem6").css('visibility', 'hidden');
        }
    })

    pass2.bind('change', function (e) {

        if(pass1[0].value != pass2[0].value) {
            $("#gridItem9").css('visibility', 'visible');
        }
        else {
            $("#gridItem9").css('visibility', 'hidden');
        }
    })

    function saveLocal() {
        localStorage.setItem("email", email[0].value);
        localStorage.setItem("password", pass1[0].value);
    }


    //console.log(clientMail);
    //let span2 = $("#client");
    //console.log(span2[0].innerText);


    window.jQuery = window.$ = jQuery

});

function checkeMail(text) {

    const email = /((^[A-z._]\w{3,15})\@([A-z.]+\.))([A-z]{2,3})$/;

    return email.test(text) ? true : false;
}

function checkPass1(text) {

    const pass1 = /^(((?=.*[a-z])(?=.*[A-Z]))|((?=.*[a-z])(?=.*[0-9]))|((?=.*[A-Z])(?=.*[0-9])))(?=.{6,})/;

    return pass1.test(text) ? true : false;
}

window.jQuery = window.$ = jQuery