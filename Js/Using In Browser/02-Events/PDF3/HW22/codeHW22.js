"use strict"

/*Создать html-страницу для отображения/редактирования текста. При открытии html-страницы текст отображается с
 помощью тега div.
При нажатии Ctrl + E вместо блока div появляется многострочное текстовое поле
textarea с тем же текстом, который теперь можно редактировать.
При нажатии Ctrl + S вместо textarea появляется div с уже измененным текстом.
Не забудьте выключить поведение по умолчанию для этих сочетаний клавиш.*/

let textDiv = document.getElementById("textDiv");
let textEdit = document.getElementById("textEdit");
let body = document.querySelector("body");

body.addEventListener("keydown", EditText);

function EditText(event) {
    let isopen = textDiv.style.visibility == "hidden";

    if(event.key == "e" && isopen == false && event.ctrlKey) {
        event.preventDefault();

        textEdit.value = textDiv.textContent;
        textDiv.style.visibility = "hidden";
        textDiv.style.height = "0px";
        textEdit.style.visibility = "visible";
        textEdit.style.height = auto;
    }
    else if(event.key == "s" && isopen == true && event.ctrlKey) {
        event.preventDefault();

        textDiv.textContent = textEdit.value;
        textEdit.style.visibility = "hidden";
        textDiv.style.visibility = "visible";
        textDiv.style.height = "auto";
    }
}