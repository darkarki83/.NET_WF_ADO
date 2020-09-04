"use strict"

function HW4() 
{
    let flag = true;
    let oneName = ``;

    let names = [];d

    while(flag) {
        let name = prompt(`Get name father name and surname ?`, `Ivan ivanich ivanov`);
        for (let i = 0 ; i < name.length; i++) {
            if(!(name.charAt(i) >= `a` && name.charAt(i) <= `z` || name.charAt(i) >= `A` && name.charAt(i) <= `Z` || name.charAt(i) == ` ` || name.charAt(i) == `.`)) {
                alert(`wrong input`);
                flag = false;
                break;
            }
            else {
                oneName += name.charAt(i);
                if(name.charAt(i) == ` ` && oneName.length > 1 || i == name.length - 1) {
                    names.push(oneName);
                    oneName = ``;
                }
            }
        }
        if(flag) {
            names.forEach((item) => alert(`your name is : ${item}`));
        }
        flag = confirm(`you wont play again?`)
    }
}
