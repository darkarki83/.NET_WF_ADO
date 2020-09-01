"use strict"

function HW1() {
    let flag = false;
    do{
        let name = prompt(`Your Name?`, `oleg`);
        let gender = prompt(`Your Gender?`, `man`);
        let age = prompt(`Your Age?`, 25);
        let mail = prompt(`Your mail?`, `art@hotmail.com`);

        flag = confirm(`name : ${name} \ngender : ${gender} \nage : ${age} \nmail : ${mail} \n`);
    }while(!flag);

    alert(`thanks`);
}
