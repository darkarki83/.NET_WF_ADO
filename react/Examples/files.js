//files works

//const fs = require( 'fs'); // fs -> file system -> модуль для работы с файлами

const fileName = "text.txt"; // file name
const to = "newtext.txt"; // file name

const configFile = "config.json";

/*var f = fs.createWriteStream(fileName, { flag: 'w' }); // open our file 

f.write(         //  async function to write
    'Hello world', 
    (after)=> {  // call back function run after writing
    if (after) {
        console.error(after);
    } else {
        console.error('Write ok');
    }
});
f.end();

fs.appendFile(fileName, "\nLine 2", (after)=>{
    if (after) {
        console.error(after);
    } else {
        console.error('Append 2 ok');
    }
});

//+ кароткий код
//-каждая команда открывфет фийл заного => worning

f = fs.createWriteStream(fileName, {flag: 'a'});

f.write("\nLine 3", (after) => {
    if (after) {
        console.error(after);
    } else {
        console.error('Append 3 ok');
    }
});

f.end();*/

/*var f1 = fs.createReadStream(fileName); 
var f2 = fs.createWriteStream('test2.txt');

f1.on(  // установка события
    'open', //event
    () => {
        f1.pipe(f2);  // from f2 to f1
});*/
copy(fileName, to);
function copy(fileName, to) {
    const fs = require( 'fs');


    // fs -> file system -> модуль для работы с файлами
   
   var f1 = fs.createReadStream(fileName); 
   var f2 = fs.createWriteStream('new.txt');

   f1.on(  // установка события
       'open', //event
       () => {
           f1.pipe(f2);  // from f2 to f1
   });

}


//read file


/*fs.readFile(configFile, 
    (err, date) => {
        if (err) {
            console.error(err);
        } else {
            console.log(date);
        }   
    });
*/

/*if(fs.existsSync(configFile)) {
fs.readFile(configFile, 
    (err, date) => {
        if (err) {
            console.error(err);
        } else {
            try {
            conf = JSON.parse(date);
            console.log(conf);
        }catch(ex) {
                console.log("Json parse error");
                console.log(ex);
            }
            
        }   
    });
} else {
    console.error(`File ${configFile} not found`);
}

/*function LogJournal(date){
    const fs = require( 'fs'); // fs -> file system -> модуль для работы с файлами

    const fileName = "text.txt"; // file name
    const configFile = "config.json";

    f = fs.createWriteStream(fileName, {flag: 'a'});

    f.write(`\n${date}`, (after) => {
        if (after) {
            console.error(after);
        } else {
            console.error('add');
        }
    });

    f.end();

}*/



















