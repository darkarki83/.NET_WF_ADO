<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
    <style>
        #grid {
            margin-top: 5%;
            display: grid;
            grid-template-areas:
                    "input1 input2"
                    "div1 div1";
            grid-template-rows: 60% 60%;
            grid-template-columns: 30% 30%;
            grid-gap: 5%;
        }

        #add {
            margin-left: 10%;
        }

        #add input {
            grid-area: input1;
            width: 100%;
            height: 100%;
            background-color: deepskyblue;
        }

        #show input {
            grid-area: input2;
            width: 100%;
            height: 100%;
            background-color: chartreuse;
        }

        #show {
            margin-left: 10%;
        }

        #ourdiv {
            grid-area: div1;
            margin-top: 5%;
            margin-left: 5%;
        }

    </style>
</head>
<body>
<article id="grid">
    <form id="add" action="addUser.php"  method="post">
        <input id="adds"  type="submit"  name="adds" value="Add" />
    </form>
    <form id="show" action="showUser.php" method="post">
        <input id="shows" type="submit"  name = "shows" value="Show"/>
    </form>
    <?php

    $myuser = fopen('user.txt', 'r+') or die("Can not be opened");
    $count = htmlentities(fgets($myuser));

    echo '<div id="ourdiv"><pre> Count ours Users : ';
    echo $count;
    echo '</pre></div>';
    fclose($myuser);
    ?>
</article>
</body>
</html>

