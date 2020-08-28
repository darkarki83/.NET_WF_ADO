"use strict"

function HW2() 
{
    let num = Math.floor(Math.random()*(101))+0;
    console.log(num);

    let mynumber = 0;
    let flag = false;
    do{
        mynumber = prompt("Get num?", `${mynumber}`);
        flag = num == mynumber;
        flag ? alert("you ar winner") : alert("you ar loss")
        flag = !confirm("Do you want to continius?")
    }while(!flag)
    alert(`bay - bay`);
}
