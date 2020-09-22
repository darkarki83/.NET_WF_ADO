"use strict"

let newWin = null;

function HW16(id)
{
    let withg = document.getElementById(id).alt.slice(0, 3);
    let hight = document.getElementById(id).alt.slice(3);

    //location.href=`index2.html?BIG${'/' + id}.jpg;`
        newWin = window.open(
            `index2.html?BIG${'/' + id}.jpg`,
            `${id}`,
            `width=${withg}, height=300, left=350, top=50, resizable=yes, menubar=yes, toolbar=yes, location=yes,` +
            ` scrollbars=yes`
        );
        //location.href=`index2.html?SMALL${'/' + id}.jpg`
    //let src = location.search.slice(1);
};

let tooltipElem;

document.onmouseover = function(event) {
    let target = event.target;
    let tooltipHtml = target.dataset.tooltip;

    if (!tooltipHtml)
        return;

    mytext.innerText = tooltipHtml;    
};
document.onmouseout = function(e) {
    let my = document.getElementById("mytext");
    if(my != undefined) {
        if (mytext.target != '') {
            mytext.innerText = '';
        }
    }
};
/*function Back(src) 
{
   //window.close('index2.html');
}*/

