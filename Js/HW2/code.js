"use strict"

function HW2() 
{
    let num = Math.floor(Math.random() * 101);
    console.log(num);

    let mynumber = 0;
    let flag = false;
    do {
        mynumber = prompt(`Get num?`, `${mynumber}`);
        flag = num == mynumber;
        flag ? alert(flag ? `you are winner` : `you are loss`);
        flag = !confirm(`Do you want to continius?`);
    } while (!flag)

    alert(`bay - bay`);
}
