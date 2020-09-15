"use strict"

let HW3 = function(){
    let down = 0;
    let up = 100;

    do {
        let half = parseInt((up + down) / 2);
        console.log(down);
        console.log(up);
        if(confirm(`your number equal : ${half}`)) {
            alert(`your number is ${half}`);
            break;
        }
        if(confirm(`your number bigeer : ${half}`)) {
            down = half + 1;
            continue;
        }
        if(confirm(`your number small : ${half}`)) {
            up = half - 1;
            continue;
        }
    } while(true)
    
}
