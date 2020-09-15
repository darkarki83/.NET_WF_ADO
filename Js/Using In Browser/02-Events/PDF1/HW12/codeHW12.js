"use strict"

let lastClick = [];
let arr = document.getElementsByTagName("li");

function ClickEvent(event) {
    console.log(event);
    let idElement = event.target;
    if(event.shiftKey == false && event.ctrlKey == false) {
        for( let i = 0;i < arr.length;i++){
            let item = document.getElementById(arr[i].id);
            item.style ="margin-right:10px";
        }
        IdSelected(idElement);
    }
    else if(event.shiftKey == true) {
        if(lastClick.length > 0) {
            let tempElem = lastClick.pop();
            let first = parseInt(tempElem.id[2]);
            let second = parseInt(idElement.id[2]);
            if(first > second) {
                let tmp = first;
                first = second - 1;
                second = tmp;
            }
            else if(first == second) {
                lastClick.push(tempElem);
                return false;
            }
            for( let i = first; i < second; i++){
                let item = document.getElementById(arr[i].id);
                IdSelected(item);
            }
        }
        else {
            lastClick.push(event.target);
            for( let i = 0;i < arr.length;i++){
                let item = document.getElementById(arr[i].id);
                item.style ="margin-right:10px";
            }
            IdSelected(idElement);
        }
    }
    else if(event.ctrlKey == true) {
        if(idElement.style.backgroundColor != "red") {
            IdSelected(idElement);
        }
        else {
            unSelected(idElement);
        }
    }
}

function IdSelected(idElement) {
    /*arr.forEach(element =>{
        console.log(element);
    });*/
    idElement.style.backgroundColor = "red";
}
function unSelected(idElement) {
    idElement.style ="margin-right:10px";
}

let li1 = document.getElementById("li1");
let li2 = document.getElementById("li2");
let li3 = document.getElementById("li3");
let li4 = document.getElementById("li4");
let li5 = document.getElementById("li5");
let li6 = document.getElementById("li6");
let li7 = document.getElementById("li7");

li1.addEventListener("click", ClickEvent);
li2.addEventListener("click", ClickEvent);
li3.addEventListener("click", ClickEvent);
li4.addEventListener("click", ClickEvent);
li5.addEventListener("click", ClickEvent);
li6.addEventListener("click", ClickEvent);
li7.addEventListener("click", ClickEvent);