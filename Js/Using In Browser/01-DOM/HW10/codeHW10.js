"use strict"

let myRadio = document.getElementsByName("radio");
function getRadioButton() {
    for (let i = 0; i < myRadio.length; i++) {
        if (myRadio[i].checked == true) {
            return myRadio[i];
        }
    }
    return null;
}
//console.log(getTextItem(getRadioButton()));

/*function getTextItem(radioCheckd) {
    if (radioCheckd != null) {
        let item = parseInt(radioCheckd.value.slice(5));
        if(item != 5) {
            return document.getElementById(`text${item}`);
        }
    }
    return null;
}*/

function buttonClick(event) {
    //console.log(event);  // for look
    let textB;
    let radioB = getRadioButton();
    let item = parseInt(radioB.value.slice(5));

    if(item != 5)
        textB = document.getElementById(`text${item}`);
    else
        textB = null;
    //console.log(`radioB : ${radioB}`);
    //console.log(`text : ${textB}`)
    //console.log(`item : ${item}`)

    event.stopPropagation();  // отменяет вложиность

    let body = document.body;
    let el = event.path[0];

    switch (item) {
        case 1:
            let ul = document.createElement("ul");
            ul.setAttribute('style', 'list-style: circle;');
            ul.setAttribute('onClick', 'buttonClick(event)');

            let text = document.createTextNode(textB.value != "" ? textB.value : "New Node");

            ul.appendChild(text);
            body.appendChild(ul);
            break;
        case 2:
            let li = document.createElement("li");
            li.setAttribute('onClick', 'buttonClick(event)');

            let text2 = document.createTextNode(textB.value != "" ? textB.value : "New Li Node");

            li.appendChild(text2);
            el.appendChild(li);
            break;
        case 3:
            let text3 = document.createTextNode(textB.value != "" ? textB.value : "Changed Node");
            let oldNode = document.querySelectorAll("div.article p")[0];

            el.replaceChild(text3, el.childNodes[0]);
            break;
        case 4:
            let ulChild = document.createElement("ul");
            ulChild.setAttribute('style', 'list-style: circle;');
            ulChild.setAttribute('onClick', 'buttonClick(event)');

            let text4 = document.createTextNode(textB.value != "" ? textB.value : "New Child Node");

            ulChild.appendChild(text4);
            el.appendChild(ulChild);
            break;
        case 5:
            let elPerent = event.path[1];
            elPerent.removeChild(el);
            break;
        default:
            break;
    }
}



