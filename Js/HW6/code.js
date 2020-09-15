"use strict"

    let currentImage = 0, count = 0;
    let path = ["image/1.jpg", "image/2.png", "image/3.jpg", "image/4.jpg", "image/5.jpg", "image/6.png", "image/7.jpg", "image/8.jpg", "image/9.jpg", "image/10.png"];
    let img = [];

    for (var i = 0; i < path.length; i++) {
        img[i] = new Image (500, 500);
        img[i].src = path[i];
        img[i].onload = countImages;
    }

    function countImages() {
        count++;
        if (count == path.length) {
            info.innerText = "Готово!";
        } else {
            info.innerText = `Загрузка изображений: ${count} из ${path.length}`;
        }
    }

    function nextImage() {
        currentImage++;
        if (currentImage == path.length) {
            currentImage = 0;
        }
        document.images["picture"].src = img[currentImage].src;
        console.log(picture);
        return false;
    }

    document.onclick = function(event) 
    {
        let target = event.target;

        //console.log(target.alt);
        if(target.src != undefined){
            currentImage = parseInt(target.alt) - 1;
            document.images["picture"].src = img[currentImage].src;
        }
        return false;
    };

    
    /*function HW5(alt) 
    {
        currentImage = alt - 1;
        document.images["picture"].src = img[currentImage].src;
        return false;
    };*/

