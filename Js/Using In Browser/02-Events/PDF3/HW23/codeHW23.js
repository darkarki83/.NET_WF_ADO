"use strict"

/*Создать html-страницу с таблицей. При клике по заголовку колонки
необходимо отсортировать данные по этой колонке. Например, на скриншоте
люди отсортированы по возрасту. Учтите, что числовые значения должны
сортироваться как числа, а не как строки.*/

let row0 = document.getElementsByClassName("row0")
let row1 = document.getElementsByClassName("row1")
let row2 = document.getElementsByClassName("row2")
let row3 = document.getElementsByClassName("row3")

let objectArray = [];
for(let i = 0; i < 4; i++) {
    objectArray.push(createPerson(row0[i].innerHTML, row1[i].innerHTML, row2[i].innerHTML,
        row3[i].innerHTML));
}

/*objectArray.sort(compareName);
for(let i = 0; i < 4; i++) {
    console.log(objectArray[i]);
}
objectArray.sort(compareSurename);
for(let i = 0; i < 4; i++) {
    console.log(objectArray[i]);
}
objectArray.sort(compareAge);
for(let i = 0; i < 4; i++) {
    console.log(objectArray[i]);
}
objectArray.sort(compareCompony);
for(let i = 0; i < 4; i++) {
    console.log(objectArray[i]);
}*/  // ONLY LOOK

/*не работает спрасить почему*//*
let sortFunctionArray = [];
sortFunctionArray.push(() => objectArray.sort(compareName));
sortFunctionArray.push(() => objectArray.sort(compareSurename));
sortFunctionArray.push(() => objectArray.sort(compareAge));
sortFunctionArray.push(() => objectArray.sort(compareCompony));*/

function draw() {
    for (let i = 0; i < sortItemLine.length; i++) {
            row0[i].innerText = objectArray[i].name;
            row1[i].innerText = objectArray[i].surename;
            row2[i].innerText = objectArray[i].age;
            row3[i].innerText = objectArray[i].company;
    }
}

let clickSort = function(event) {
    let element = event.target;
    let index = element.id.slice(4,);

    if(index == 0)
        objectArray.sort(compareName);
    else if(index == 1)
        objectArray.sort(compareSurename);
    else if(index == 2)
        objectArray.sort(compareAge);
    else if(index == 3)
        objectArray.sort(compareCompony);

    draw();
}

let sortItemLine = document.getElementsByClassName("sorts");
for (let i = 0; i < sortItemLine.length; i++) {
    sortItemLine[i].addEventListener("click",clickSort);
}



