"use strict"

const delay = 30;                    // Задержка (в 
const R = 120;                        // Радиус 
const da = 3 * Math.PI / 180;        // Приращение 
let a = 0;     // Угол (в 

let Arr = [];                      
function moveElem() {
  
    elemToMove.style.left = Arr[0] + R * Math.cos(a) + "px";
    elemToMove.style.top = Arr[1] + R * Math.sin(a) + "px";

    a += da;
}
/*function mouseMove(e) {
    //elemToMove.left = MouseEvent.

    Arr[0] = e.pageX; // Координата X курсора
    Arr[1] = e.pageY; // Координата X курсора
  console.log(`X :  ${e.pageX}", Y : ${e.pageY}`)
}*/
//page.onmousemove = mouseMove;

document.onmousemove = function(e) {
        Arr[0] = e.pageX; // Координата X курсора
        Arr[1] = e.pageY; // Координата Y курсора
      console.log(`X :  ${e.pageX}", Y : ${e.pageY}`)
};

/*function mouseCoords(e) {
    // Для браузера IE
    if (document.all)  { 
        elemToMove.left = event.x + document.body.scrollLeft; 
      y = event.y + document.body.scrollTop; 
    // Для остальных браузеров
    } else {
      x = e.pageX; // Координата X курсора
      y = e.pageY; // Координата Y курсора
    }
    document.getElementById("coords").innerHTML = "X : " + x + ", Y : " + y;
    console.log(`X :  ${x}", Y : ${y}`)
   }*/