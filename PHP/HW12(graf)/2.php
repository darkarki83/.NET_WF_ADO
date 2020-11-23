<?PHP
header ("content-type: image/gif");
$id = imagecreate(900,600);
imagecolorallocate($id,200,200,200);
$n=rand(1,100);
//$n - случайное количество создаваемых фигур
for ($i=0;$i<$n;$i++)
    $color[$i] = imagecolorallocate($id,rand(0,255),rand(0,255),rand(0,255));
$color_arc = imagecolorallocate($id,198,0,212);
for ($i=0;$i<$n;$i++)
{
//описываю случайные размеры фигур и создаю их
    $x1=rand(0,600);
    $y1=rand(0,400);
    $x2=$x1+200;
    $y2=$y1+200;
    imagefilledrectangle($id,$x1,$y1,$x2,$y2,$color[$i]);
}

imagegif($id);

imagedestroy($id);


echo "Сообщение после рисунка.";
?>
