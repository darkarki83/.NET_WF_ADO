"use strict"

$(document).ready( function () {

    $("#ready").bind("click", ClickReady);
    $("#reset").bind("click", delCookie);

    let radio = $('input[name$="radio_gender"]');

    for (const item of $('input[name$="radio_gender"]')) {
        console.log(item.checked);
    }

    let checkboxs = $('input[type$="checkbox"]');

    for (const checkb of $('input[type$="checkbox"]')) {
        console.log(checkb);
    }

    let list_work = $('select[name$="list_work"]')[0];



    console.log($('input[name$="e_mail"]')[0]);

    documentLoad();

    function ClickReady(event) {
        let flag = false;

        if ($("#password1")[0].value < 3) {
            alert("password wery short !!! try again ");
            return false;
        } else if ($("#password1")[0].value != $("#password2")[0].value) {
            alert("confirm not matches password : try again");
            return false;
        }

        for (const item of radio) {
            if(item.checked) {
                flag = true;
            }
        }

        if(flag)
            flag = false;
        else
            return false;

        for (const checkbox of checkboxs) {
            if(checkbox.checked) {
                flag = true;
            }
        }

        if(flag)
            flag = false;
        else
            return false;

        AddCookie();

        return true;
    }

    function AddCookie() {
        let d = new Date();
        d.setMonth(d.getMonth() + 6);

        let looklogin = $("#login")[0].value;
        console.log(looklogin);
        console.log($('input[name$="login"]').value);
        document.cookie = "login=" + $("#login")[0].value + ";path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "password=" + encodeURIComponent($("#password1")[0].value) +";path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "confirm=" + $("#password2")[0].value + ";path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "name=" + $("#name")[0].value + ";path=/;expires=" + d.toUTCString() + ";";
        for (const item of radio) {
            if(item.checked) {
                document.cookie = "radio-gender=" + item.value + ";path=/;expires=" + d.toUTCString() + ";";
                break;
            }
        }
        for (const checkbox of checkboxs) {
            if(checkbox.checked) {
                document.cookie = `${checkbox.name}=` + "on" + ";path=/;expires=" + d.toUTCString() + ";";
            }
        }
        for (const options of list_work) {
            if(options.selected) {
                document.cookie = "list_work=" + options.value + ";path=/;expires=" + d.toUTCString() + ";";
                break;
            }
        }
        document.cookie = "e_mail=" + $('input[name$="e_mail"]')[0].value + ";path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "text_info=" +$('textarea[name$="text_info"]')[0].value + ";path=/;expires=" + d.toUTCString() + ";";
    }

    function delCookie() {
        let d = new Date();
        d.setMonth(d.getMonth() - 1);
        document.cookie = "login=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "password=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "confirm=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "name=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "radio-gender=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "list_work=;path=/;expires=" + d.toUTCString() + ";";
        for (let i = 0; i < checkboxs.length; i++) {
            document.cookie = `${checkboxs[i].name}=;path=/;expires=` + d.toUTCString() + ";";
        }
        document.cookie = "e_mail=;path=/;expires=" + d.toUTCString() + ";";
        document.cookie = "text_info=;path=/;expires=" + d.toUTCString() + ";";
    }

    function documentLoad() {
        let str = document.cookie;
        console.log(str);
        if(document.cookie != 0) {
            let arr = str.split(";");
            $("#login")[0].value = arr[0].split('=')[1];
            $("#password1")[0].value = arr[1].split("=")[1];
            $("#password2")[0].value = arr[2].split("=")[1];
            $("#name")[0].value = arr[3].split("=")[1];
            for (let i = 0; i < 2; i++) {
                if (radio[i].value = arr[4].split("=")[1]) {
                    radio[i].checked = true;
                    break;
                }
            }
            let count = 0;
            for (let i = 0; i < checkboxs.length; i++) {
                if (arr[5 + count].split("=")[0].trim() == checkboxs[i].name) {
                    checkboxs[i].checked = true;
                    count++;
                }
            }

            for (let i = 0; i < list_work.length; i++) {
                if (list_work[i].value = arr[5 + count].split("=")[1]) {
                    list_work[i].selected = true;
                    break;
                }
            }
            $('input[name$="e_mail"]')[0].value = arr[6 + count].split("=")[1];
            $('textarea[name$="text_info"]')[0].value = arr[7 + count].split("=")[1];
        }
    }
})
window.jQuery = window.$ = jQuery