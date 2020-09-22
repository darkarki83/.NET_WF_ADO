"use strict"

let text_login = document.getElementById("text_login");
text_login.addEventListener("loginValidator", onkeydown);


let password1 = document.getElementById("password1");
let password2 = document.getElementById("password2");
password1.addEventListener("change", LoginValidator);
password1.addEventListener("change", LoginValidator);

function LoginValidator() {
    let flag = false;
    let password1 = document.getElementById("password1");
    let password2 = document.getElementById("password2");

    if (password1.value != password2.value)
    {
        alert("Your pasword no Confirmation try again");
        return false;
    }
    let radio = document.getElementsByName("radio-sex");

    for(let i = 0; i < radio.length; i++) {
        if(radio[i].checked)
        {
            flag = true;
            break;
        }
    }
    if(!flag) {
        alert("You no checkd sex");
        return false;
    }
    else
        flag = false;

    let checkbox = document.getElementsByClassName("checkbox");

    for(let i = 0; i < checkbox.length; i++) {
        if(checkbox[i].checked)
        {
            flag = true;
            break;
        }
    }
    if(!flag) {
        alert("You no checkd Specialization");
        return false;
    }
    else
        flag = false;

    return true;
}
let ele = document.getElementById('myForm') ;/*Your Form Element*/;
if(ele.addEventListener) {
    ele.addEventListener("submit", newWindow, false);  //Modern browsers
}

let newWin = null;

function newWindow() {
    let str = location.href;
    console.log(str);

    newWin = window.open(
        `${str}`,
        `index2`,
        `width=500, height=300, left=350, top=50, resizable=yes, menubar=yes, toolbar=yes, location=yes,` +
        ` scrollbars=yes`
    );

}