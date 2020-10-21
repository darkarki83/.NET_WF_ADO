
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Title</title>
</head>
<body style="border: 1px solid black">
<section >
    <div style = " background-color: black;width: 500px ; height:730px;">
        <header>
            <h3 style="font-weight: bold;margin-left: 900px;margin-top: 0px">
                <p>ORGANAIZER</p>
                <details>
                    <div style="border: 1px solid black ;float:right;width: 900px;height: 50px;margin-right: -580px">
                    </div>
                </details>
            </h3>
        </header>
        <article>
            <form  method="post" action="">
                <table style="border: 1px solid white; width:400px;height: 300px;margin-left: 200px
                ;margin-top: 200px;padding-left: 20px">
                    <tr>
                        <td>
                            <label style="color:white">
                                NameEvents
                                <br> <input type="text" name="NameEvents" required value ="Name :" style ="width: 250px">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label style="color:white">
                                AboutEvents
                                <br> <input type="text" name="AboutEvents" required value ="About :" style ="width: 250px">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label style="color:white">
                                TimeEvents
                                <br> <input type="time" name="TimeEvents" required value ="Time :" style ="width: 250px">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <label style="color:white">
                                DayEvents
                                <br> <input type="date" name="DayEvents" required value ="Day :" style ="width: 250px">
                            </label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input type="submit" name="add" value ="Add" style ="width: 257px"/>
                        </td>
                    </tr>
                </table>
            </form>
        </article>
    </div>
</section>
</body>
</html>
<?php

include_once('organizer.php');


    $org = new organizer();

    $name_event = 'встреча';
    $about_event = 'по работе';
    $hour = 5;
    $day = date('Y-m-d H', strtotime('2010-10-10 ') + $hour * 60 * 60);


    $org->create_event_part($name_event, $about_event, $hour, $day);

    $zam = new events('обед', 'обед с друзьями', 13, date('Y-m-d H', strtotime('2003-10-10 ') + 13 * 60 * 60));


    $org->create_event($zam);


    $org->print_org();

    $org->SortByDate();

    $org->print_org();

    if(get_class($org) == "organizer")
    {
        echo "this is object Class organizer";
        print '<br />';
    }
    if($org instanceof organizer)
    {
        echo "this is True";
        print '<br />';
    }
    foreach ((get_class_methods("organizer")) as $key=>$value )
    {
        echo "<b> $key </b>  => $value() <br />";
    }
foreach ((get_class_vars("organizer")) as $key=>$value )
{
    echo "<b> $key </b>  => $value() <br />";
}


function addToOrg($org)
{
    if(isset($_REQUEST['add'])) {
        $org->create_event(newEvent());
        $org->print_org();
    }
}

function newEvent(){
    $name = $_REQUEST['NameEvents'];
    $about = $_REQUEST['AboutEvents'];
    $time = $_REQUEST['TimeEvents'];
    $day = $_REQUEST['DayEvents'];

    $event = new events($name, $about, $time, $day);
    return $event;
}
?>