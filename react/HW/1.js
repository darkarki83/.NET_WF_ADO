const fs = require( 'fs');

const from = 'text.txt'; 
const to = 'new.txt'; 


copy(from, to)

function copy(from, to) {

     // fs -> file system -> модуль для работы с файлами
    
   /* var f1 = fs.createReadStream(from); 
    var f2 = fs.createWriteStream(to);

    f1.on(  // установка события
        'open', //event
        () => {
            f1.pipe(f2);  // from f2 to f1
    });*/

    var r = fs.readFile( from, (err, date) => {
            if( err ) {
                console.error(err);
            }else{
                var w = fs.createWriteStream(to, {flag: 'a'});
                w.write(date.toString(), (err) => {
                    if( err ) {
                        console.error(err);
                    }else{
                        console.log('write');
                    }
                });
            }
        });
    return true;
}