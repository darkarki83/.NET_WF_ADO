"use strict"

/*
* Создать html-страницу с возможностью бронирования билетов на поезд.
* Для начала пользователь выбирает направление поезда и дату поездки, а затем отмечает места
* для брони.
Предусмотреть возможность просмотра уже забронированных билетов. Необходимо хранить информацию
* в заранее подготовленных массивах*/



//let cheackboxs = jQuery("cheackbox");
/*let search = $("#search");

console.log(search[0]);   games jQuery  :)))))
*/
search = document.getElementById("search");                 // id button search
search.addEventListener("click", ClickSearch);

let mybook = document.getElementById("mybook");                // id button book
mybook.addEventListener("click", ClickBook );

let checkbox = document.getElementsByClassName("cbox");   // all checkboxs
for (let i = 0; i < checkbox.length; i++) {
    checkbox[i].addEventListener("change", AddPrice);
}
let city = document.getElementById("city");

let money = 0;
let price = document.getElementById("money");              // id label money
let tdate= document.getElementById("tdate");

let artseats = document.getElementById("artseats");
let artnoseats = document.getElementById("artnoseats");

function AddPrice(event) {                                          // function (change money + and update label)
    money = event.target.checked ? money += 20 : money -= 20;
    price.innerText = money;
}

for (let i = 0; i < checkbox.length; i++) {
    if(checkbox[i].checked)
        checkbox[i].addEventListener("change", AddPrice);
}

function ClickSearch() {
    let i = 0;
    for (i; i < allTrains.length; i++) {
        if (city.selectedOptions[0].innerText == allTrains[i].direction) {
            if (tdate.value == allTrains[i]["date"]) {
                LoadThisTickets(i);
                tickets.style.visibility = "hidden";
                tickets.style.height = "0px";

                VisibilityHeight("visible", "150px", "hidden", "0px");
                break;
            }
        }
    }
    if(i == allTrains.length) {
        VisibilityHeight("hidden", "0px", "visible", "100px");
    }
}

function LoadThisTickets(i) {
    for (let j = 0; j < allTrains[i].seats.length; j++) {
        if(allTrains[i].seats[j] == 1) {
            checkbox[j].disabled = false;
            checkbox[j].checked = false;
        } else if(allTrains[i].seats[j] == 0) {
            checkbox[j].checked = false;
            checkbox[j].disabled = true;
        }
    }
    money = 0;
    price.innerText = money;
}

function VisibilityHeight(svis, shei, novis, nohei) {
    artseats.style.visibility = svis;
    artseats.style.height = shei;
    artnoseats.style.visibility = novis;
    artnoseats.style.height = nohei;
}

function ClickBook() {
let tmp = [];
    for (let i = 0; i < allTrains.length; i++) {
        if (city.selectedOptions[0].innerText == allTrains[i].direction) {
            if (tdate.value == allTrains[i]["date"]) {
                for (let j = 0; j < checkbox.length; j++) {
                    if(checkbox[j].checked == true) {
                        allTrains[i].seats[j] = 0;
                        checkbox[j].disabled = true;

                        console.log(tdate.value);
                        tmp.push(createTicket(city.selectedOptions[0].innerText, tdate.value, checkbox[j].value));
                    }
                }
                LoadThisTickets(i);
            }
        }
    }
    let mytable = document.getElementById("mytable");
    let first = document.getElementById("first");
    tickets.style.visibility = "visible";
    tickets.style.height = "auto";

    for (let i = 0; i < tmp.length; i++) {
        let tr = document.createElement("tr");
        let td0 = document.createElement("td");
        let elemtext = document.createTextNode(tmp[i].direction);
        td0.appendChild(elemtext);
        tr.appendChild(td0);

        let td1 = document.createElement("td");
        elemtext = document.createTextNode(tmp[i].date);
        td1.appendChild(elemtext);
        tr.appendChild(td1);

        let td2 = document.createElement("td");
        elemtext = document.createTextNode(tmp[i].seats);
        td2.appendChild(elemtext);
        tr.appendChild(td2);

        mytable.insertBefore(tr, mytable.l);
    }
}

window.jQuery = window.$ = jQuery

