<?php

namespace App\Http\Controllers;

use Illuminate\Http\Request;
use App\Http\Requests\userRequest;
use App\Models\Log;


class userController extends Controller{

    public function submit(userRequest $req) {

        $log = new Log();
        $log->name = $req->input('name');
        $log->password = $req->input('password');

        $log->save();

        return redirect()->route('home')->with('success', 'login in');
    }

}


