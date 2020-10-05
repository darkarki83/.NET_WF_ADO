"use strict"

function createTicket(bookdirection, bookdate, bookseat) {

    return {
        direction : bookdirection,
        date : bookdate,
        seats : bookseat
    };
};

let ticarray = [];

function DirDateSeat(spasialdirection, spasialdate, spasialcost) {
    return {
        direction: spasialdirection,
        date: spasialdate,
        seats: new Array(30).fill(1),
        cost: spasialcost,
        setSeats : function (number) {
            this.seats[number] = 0;
        }
    };
};

let allTrains = [];
allTrains.push(DirDateSeat("lviv-odessa", "2020-05-02", 30));
allTrains.push(DirDateSeat("lviv-odessa", "2020-05-01", 30));
allTrains.push(DirDateSeat("lviv-kiev", "2020-05-02", 30));
allTrains.push(DirDateSeat("kiev-lviv", "2020-05-02", 30));
allTrains.push(DirDateSeat("odessa-kiev", "2020-05-02", 30));
allTrains.push(DirDateSeat("kiev-odessa", "2020-05-02", 30));

/*for (const allTrain of allTrains) {
    console.log(allTrain);
}*/