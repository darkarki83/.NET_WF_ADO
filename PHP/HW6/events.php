<?php

class events
{
    private $name_event;
    private $about_event;
    private $hour;
    private $day;

    function __construct($name_event, $about_event, $hour, $day)
    {
        $this->name_event = $name_event;
        $this->about_event = $about_event;
        $this->hour = $hour;
        $this->day = $day;
    }

    function get_name()
    {
        return $this->name_event;
    }

    function set_name($name_event)
    {
        $this->name_event = $name_event;
    }

    function get_about()
    {
        return $this->about_event;
    }

    function set_about($about_event)
    {
        $this->about_event = $about_event;
    }

    function get_hour()
    {
        return $this->hour;
    }

    function set_hour($hour)
    {
        $this->hour = $hour;
    }

    function get_day()
    {
        return $this->day;
    }

    function set_day($day)
    {
        $this->day = $day;
    }

}

?>