"use strict"

function HW6() 
{
    let adress = "http://wwww.ufa.com.ua/utilites/hdd/out.php?sort=2";
    
    let flag = true;
    let temp = "";
    let oneName = "";

    let names = [];

    let lastindex = adress.indexOf('/');
    names[0] = adress.slice(0, lastindex);
    let tempStr = adress.slice(lastindex + 2);

    lastindex = tempStr.indexOf('/');
    names[1] = tempStr.slice(0, lastindex);
    tempStr = tempStr.slice(lastindex);

    lastindex = tempStr.lastIndexOf('/');
    names[2] = tempStr.slice(0, lastindex + 1);
    tempStr = tempStr.slice(lastindex + 1);

    lastindex = tempStr.lastIndexOf('?');
    names[3] = tempStr.slice(0, lastindex);
    tempStr = tempStr.slice(lastindex + 1);
    
    names[4] = tempStr;

    console.log(names);
    names.forEach(element => {
        console.log(`${element}` + `\n`);
        document.write(element + "<br />");
    });
}
