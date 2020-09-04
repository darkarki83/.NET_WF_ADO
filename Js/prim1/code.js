"use strict"

function prim() 
{
    let adress = "http://wwww.ufa.com.ua/utilites/hdd/out.php?sort=2" 
    let flag = true;
    let temp = "";
    let oneName = "";

    let names = [];

   
        for (let i = 0 ; i < adress.length; i++) {
            if(names.length == 0) {
                if(adress.charAt(i) == `/`) {
                    i++;
                    names.push(oneName);
                    oneName = "";
                    continue;
                }

                oneName += adress.charAt(i);
            }
            if(names.length == 1) {
                if(adress.charAt(i) == `/`) {
                    i--;
                    names.push(oneName);
                    oneName = "";
                    continue;
                }
                oneName += adress.charAt(i);
            }
            if(names.length == 2) {
                if(adress.charAt(i) == `/`) {
                    oneName += adress.charAt(i);
                    temp += oneName;
                    console.log(temp);
                    oneName = "";
                    continue;
                }
                if(adress.charAt(i) == `.`) {
                    names.push(temp);
                    oneName += adress.charAt(i);
                    console.log(oneName);
                    continue;
                }
                oneName += adress.charAt(i);
                console.log(oneName);
            }
            if(names.length == 3) {
                if(adress.charAt(i) == `?`) {
                    names.push(oneName);
                    oneName = "";
                    console.log(names);
                    continue;
                }
                oneName += adress.charAt(i);
                console.log(oneName);
            }
            if(names.length == 4) {
                if(i == adress.length - 1) {
                    oneName += adress.charAt(i);
                    names.push(oneName);
                    oneName = "";
                    console.log(names);
                    continue;
                }
                oneName += adress.charAt(i);
                console.log(oneName);
            }
        }
}
