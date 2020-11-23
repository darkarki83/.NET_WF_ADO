<?php

function cube()
{
    $image = @imagecreate(500, 500) or die('Cannot initialize');
    $backg = imagecolorallocate($image, 255, 255, 255);

    $cube = rand(25, 50);
    $count = (int)(500 / $cube);

    for ($j = 0; $j < $count; $j++) {
        for ($i = 0; $i < $count; $i++) {
            try {

                $red = rand(0, 254);
                $green = rand(0, 254);
                $blue = rand(0, 254);
                $color = imagecolorallocate($image, $red, $green, $blue);
                imagefilledrectangle($image, 0 + $j * $cube, 0 + $i * $cube, $cube + $j * $cube, $cube + $i * $cube, $color);
            } catch (Exception $ex) {
                echo($ex->getMessage());
            }
        }
    }

    header("Content-Type: image/png");

    imagepng($image, 'image.png');
    imagepng($image);

    imagedestroy($image);

}

function runMyFunction()
{
    $img = imagecreatefrompng('image.png');

    imagefilledellipse($img, 100, 100, 100, 100, 0x0000FF);



    imagepng($img);
}

if (!isset($_GET['hello'])) {
    cube();
}
else {
    runMyFunction();
}


?>
