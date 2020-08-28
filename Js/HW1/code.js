"use strict"

function HW1() 
{
    let thetrue = false;
    do{
        let name = prompt("Your Name?", "oleg");

        let gender = prompt("Your Gender?", "man");

        let age = prompt("Your Age?", 25);

        let mail = prompt("Your mAIL?", "art@hotmail.com");

        thetrue = confirm(`name : ${name} \ngender : ${gender} \nage : ${age} \nmail : ${mail} \n`);
    }while(!thetrue);

    alert("thanks");


}
