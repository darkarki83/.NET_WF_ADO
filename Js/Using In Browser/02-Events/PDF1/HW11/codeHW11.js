"use strict"

/*Создать html-страницу с деревом вложенных директорий. 
При клике на элемент списка он должен сворачиваться или разворачиваться. 
При наведении мышки на элемент шрифт должен становится жирным.
2. */
function ClickToListHendler(e) {

    //let temp = e.srcElement.id;
    let div = document.getElementById(`div${temp[2]}`);
    //let div = getElementById(`div${temp[temp.lengh - 1]}`)
    if(div != null) {
        if( div.style.visibility == "hidden") {
            div.style.visibility = "visible";
            div.style.height = "auto";
        }
        else {
            div.style.visibility = "hidden";
            div.style.height = "0";
        }
    }
    else{
        return false;
    }
}
function Handler(e)
{  
    if(div4.style.visibility == "hidden") {
        div1.style.visibility = "hidden";
        div1.style.height = "0";
        div2.style.visibility = "hidden";
        div2.style.height = "0";
        div3.style.visibility = "hidden";
        div3.style.height = "0";
    }
    //e.stopPropagation();    
}
function OverMouse(e)
{
    let div;
    console.log(e.path[0].id);
    if(e.path[0].id != undefined) {
        div = e.path[0].id;
        div.style.fontWeight = 'bold';
    }
    console.log(div);
}

let pc = document.getElementById("div5");
let c = document.getElementById("div1");
let d = document.getElementById("div2");
let e = document.getElementById("div3");

pc.addEventListener("click", ClickToListHendler, true);
pc.addEventListener("click", Handler);
c.addEventListener("click", ClickToListHendler);
d.addEventListener("click", ClickToListHendler);
e.addEventListener("click", ClickToListHendler);

document.body.onmouseover = function(event) 
    {
        let target = event.target;
        if(target != null) {
            target.style.fontWeight = 'bold';
            //console.log(target);
        }
        return true;
    };

document.body.onmouseout = function(event) 
    {
        let target = event.target;
        //console.log(target);
        if(target != null) {
            target.style.fontWeight = 'normal';
            //console.log(target);
        }
        return true;
    };

