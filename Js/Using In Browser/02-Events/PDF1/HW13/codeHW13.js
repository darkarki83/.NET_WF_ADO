"use strict"

let myBody = document.getElementById("myBody");
let div1 = document.getElementById("div1");
let mySpan = document.getElementById("span1");

let flag = false, myX, myY;

function myMouseDown(event) {

    flag = true
    myX = event.offsetX;
    myY = event.offsetY;
    console.log("myMouseDown");
}

function myMouseUp(event) {
    flag = false;
    console.log("myMouseUp");
}

function myMouseMove(event) {
    console.log(`X : ${event.offsetX} , Y : ${event.offsetY}`);
    div1.style.width = 500 + event.offsetX - myX + "px";
    console.log(div1.style.width);
    div1.style.height = 200 + event.offsetY - myY + "px";
}

div1.addEventListener("mousedown", myMouseDown);
myBody.addEventListener("mousemove", myMouseMove);
div1.addEventListener("mouseup", myMouseUp);

car.addEventListener("mousedown", DownHandler);
car.addEventListener("mouseup", UpHandler);
