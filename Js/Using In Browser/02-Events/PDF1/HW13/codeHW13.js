"use strict"

let myBody = document.getElementById("myBody");
let div1 = document.getElementById("div1");
let mySpan = document.getElementById("span1");

let flag = false, myX, myY;

function myMouseDown(event) {

    flag = true;
    myX = event.offsetX;
    myY = event.offsetY;
    //console.log("myMouseDown");
}

function myMouseUp(event) {
    flag = false;
    console.log("myMouseUp");
}

function myMouseMove(event) {
    if(flag == true) {
        //console.log(`X : ${div1.style.width} , Y : ${div1.style.height}`);
        //console.log(`X : ${parseInt(div1.style.width.slice(0,3))} , Y : ${parseInt(div1.style.height.slice(0,3))}`);
        div1.style.width = 100 + event.offsetX  + "px";
        //console.log(div1.style.width);
        div1.style.height = 100 + event.offsetY  + "px";
    }
}

div1.addEventListener("mousedown", myMouseDown);
myBody.addEventListener("mousemove", myMouseMove);
div1.addEventListener("mouseup", myMouseUp);

//car.addEventListener("mousedown", DownHandler);
//car.addEventListener("mouseup", UpHandler);
