<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body>
    <div style="text-align: center">
        <img src="img.php" id="button">
    </div>

    Hello there!
    <a href='index.php?hello=true'>Run PHP Function</a>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/2.2.0/jquery.min.js"></script>
    <script>
        $(document).ready(function(){
            $("#button").click(function(event){
                var x = event.clientX;
                var y = event.clientY;
                $.get(
                    "index.php",
                    {x: x, y: y},
                    function(php){alert(data)}
                )
            });
        });
        //document.getElementById('buttos').src='2.php';

    </script>

</body>
</html>




