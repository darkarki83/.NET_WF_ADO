<?php
include_once('events.php');


class organizer
{
    private $book = array();
    public $art = 50000;

    public function __construct()
    {

    }

    public function  create_event_part($name_event, $about_event, $hour, $day)
    {
        $event = new events($name_event, $about_event, $hour, $day);
        $this->book[] = $event;
    }

    public function create_event($event)
    {
        $this->book[] = $event;
    }

    public function SortByDate()
    {
        uasort($this->book, 'cmp');

    }

    public function change_event($index,$name_event, $about_event, $hour, $day )
    {
        $this->book[$index].set_name($name_event);
        $this->book[$index].set_about($about_event);
        $this->book[$index].set_hour($hour);
        $this->book[$index].set_day($day);
    }

    function get_for_change_event($index)
    {
        return $this->book[$index];
    }

    function delete_event($index)
    {
        if (count($this->book) > $index) {
            unset($this->book[$index]);
        }
    }

    function print_org()
    {
        foreach ($this->book as $item)
        {
            echo $item->get_name();
            echo '<br>';

            echo $item->get_about();
            echo '<br>';

            echo $item->get_hour();
            echo '<br>';

            echo $item->get_day();
            echo '<br>';
            echo '<br>';
        }
    }

}

function cmp($a,$b)
{
    // функция, определяющая способ сортировки
    if ($a->get_day() < $b->get_day()) return -1;
    elseif ($a->get_day() == $b->get_day()) return 0;
    else return 1;
}

?>