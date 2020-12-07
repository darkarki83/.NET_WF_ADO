<?php

namespace App\Http\Controllers;

use App\Models\cities;
use App\Models\countries;
use Illuminate\Http\Request;
use resources\views\rest;

class CountryController extends Controller
{
    public $ID_City = 0;

    /**
     * Display a listing of the resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function index()
    {
        //вывод список (обьектов с таблицы)


        $all_c = new countries();
        $city = new cities();
        /*if(isset($_REQUEST['publication_id'])){
            dd($_REQUEST['publication_id']);
        }*/
        //dd($all_c->all());
        //dd($all_c->all(), $city->all());
        //$type = $_REQUEST['Country'];
        //echo $type;
        //dd($type);

        return view('rest', ['date' => $all_c->all(), 'city' => $city->all()]);
    }

    /**
     * Show the form for creating a new resource.
     *
     * @return \Illuminate\Http\Response
     */
    public function create()
    {
        //новая сущность

    }

    /**
     * Store a newly created resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @return \Illuminate\Http\Response
     */
    public function store(Request $request)
    {

        $request->input('Country');
        // post (отправка в базу новой записи)
       dd($request);



    }

    /**
     * Display the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function show($id)
    {
        //

    }

    /**
     * Show the form for editing the specified resource.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function edit($id)
    {
        //редактирование палей в базе
    }

    /**
     * Update the specified resource in storage.
     *
     * @param  \Illuminate\Http\Request  $request
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function update(Request $request, $id)
    {
        //
    }

    /**
     * Remove the specified resource from storage.
     *
     * @param  int  $id
     * @return \Illuminate\Http\Response
     */
    public function destroy($id)
    {
        //удоления
    }
}
