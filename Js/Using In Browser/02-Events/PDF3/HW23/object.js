"use strict"

function createPerson(rowName, rowSurename, rowAge, rowCompany) {

    return {
        name: rowName,
        surename: rowSurename,
        age: rowAge,
        company: rowCompany
    };
};

function compareName(a, b) {
    return a.name >= b.name ? 1 : -1;
};

function compareSurename(a, b) {
    return a.surename >= b.surename ? 1 : -1;
};

function compareAge(a, b) {
    return parseInt(a.age) - parseInt(b.age);
};

function compareCompony(a, b) {
    return a.company >= b.company ? 1 : -1;
};


