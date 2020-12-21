/*  date base  */




// 1. пакеты.  
// ФАЙЛ -- МОДУЛЬ,
// каталог -- паке
// npm - node package manager - упровление покетами
// 1.1. инициализация - npm init 

// 2. доп пакеты зависимости - mysql2
// npm install mysql2

// 3. used :

const mysql = require('mysql2');
const fs = require('fs');

const CONFIG_FILE = 'config.json';

var config;  //  config from file
var con;     // bd connection
undefined

if(fs.existsSync(CONFIG_FILE)) {
    fs.readFile(CONFIG_FILE, (err, date) => {
        if(err) {
            console.error(err);
            return;  // pririvanie vmesto else
        }

        try {
            config = JSON.parse(date);
            con = mysql.createConnection(config.database);  // connection
            //console.log(config.database);
            //createTable();
            //addNumber();

            showAll();
        } catch(ex) {
            console.error(ex);
        }
    });
} else {
    console.error(CONFIG_FILE + 'not found'); 
}

async function showAll() {
    if(typeof config == 'undefined') {
        throw "Config undefined (addNumber)"; // exceptions
    }

    // mysql2 - promise interface
    var conp = con.promise();
    conp.query('SELECT * FROM numbers')
        .then((date, def) => {

            for(i = 0; i < 1 ; i++) {
                console.log(date[i]);
            }
        con.end();
        }).catch(console.error);
}

/*async function addNumber() {
    if(typeof config == 'undefined') {
        throw "Config undefined (addNumber)"; // exceptions
    }

    // mysql2 - promise interface
    var conp = con.promise();
    conp.query('INSERT INTO numbers (val, moment) VALUES (' + parseInt(Math.random() * 100) + ', CURRENT_TIMESTAMP)')
        .then((date) => {
            if(date) {
                console.log(date);
            } 
            con.end();
        });

}*/

/*async function createTable() {
    if(typeof config == 'undefined') {
        throw "Config undefined (create table)"; // exceptions
    }

    con.query(
        // запрос (strins)
        `CREATE TABLE IF NOT EXISTS numbers
        (id INT PRIMARY KEY AUTO_INCREMENT,
         val INT,
         moment DATETIME) ENGINE = InnoDB DEFAULT CHARSET = utf8`,
        // callback
        (err, date) => {
            if(err) {
                console.error(err);
            } else {
                console.log(date);
                
            }
            //con.end();
        }
    );
}*/