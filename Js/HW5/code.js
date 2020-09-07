"use strict"

function HW5(src) 
{
    let win = window.open();
    win.document.write(`<h2>Выбери меня</h3>`);
    win.document.write(`<img style="width: 500px; height: 500px;" src=${src}  alt="1">  <br>`);   

    //let win = window.open('index2');
    //win.document.write(`<img style="width: 500px; height: 500px;" src=${src}  alt="1">  <br>`);   
    
};

let tooltipElem;
    
document.onmouseover = function(event) {
    let target = event.target;
    console.log(target);
    // если у нас есть подсказка...
    let tooltipHtml = target.dataset.tooltip;
    //console.log(`1 + ${tooltipHtml}`);
    if (!tooltipHtml) return;
    
    //console.log(mytext);
    //console.log(tooltipHtml);
    mytext.innerText = tooltipHtml;    
};
    
document.onmouseout = function(e) {
    if(mytext.target != '') {
        mytext.innerText = '';
    }
};
/*function Back(src) 
{
   //window.close('index2.html');
}*/

