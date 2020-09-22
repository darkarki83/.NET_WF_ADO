"use strict"

/*Создать html-страницу с блоками информации, которые открываются по щелчку на заголовок.
В один момент времени может быть развернут только один блок информации.*/

let allp = document.getElementsByTagName("p");
let divs = document.getElementsByTagName("div");

for (let i = 0; i < divs.length; i++)
    divs[i].addEventListener("click", divClick);

function closeDiv(index) {
    allp[index].style.visibility = "hidden";
    divs[index].style.height = "40px";
}

function closeAll() {
    for (let i = 0; i < allp.length; i++) {
        if(allp[i].style.visibility == "visible"){
            closeDiv(i);
        }
    }
}

function divClick(event) {
    let element = event.target;
    let num = parseInt(element.id.slice(3,));

    if(allp[num].style.visibility == "visible") {
        closeDiv(i);
    }
    else {
        closeAll();
        allp[num].style.visibility = "visible";
        divs[num].style.height = "auto";
    }
}

