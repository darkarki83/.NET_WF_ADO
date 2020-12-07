<?php

namespace App\Http\Controllers;

use App\Models\cities;
use Illuminate\Http\Request;
use App\Http\Requests\userRequest;
use App\Models\Log;
use App\Models\countries;



class userController extends Controller{

    public function submit(userRequest $req) {

        $log = new Log();
        $log->name = $req->input('name');
        $log->password = $req->input('password');

        $log->save();

        return redirect()->route('home')->with('success', 'login in');
    }

    public function allUser() {
        $all_c = new Log();
        return view('home', ['date' => $all_c->all()]);
    }

    public function allCountries() {
        $all_c = new countries();
        $city = new cities();
        return view('home', ['date' => $all_c->all(), 'city' => $city->all()]);
    }
    public function allCities() {
        $all_c = new cities();
        //dd($all_c->all());
        //dd($all_c->where('country_fk', '=', 1)->get());
        return view('home', ['city' => $all_c->where('country_fk', '=', '2')->get()]);

    }

}


