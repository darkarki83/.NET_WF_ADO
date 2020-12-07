<?php

use Illuminate\Support\Facades\Route;
use App\Http\Controllers\userController;
/*
|--------------------------------------------------------------------------
| Web Routes
|--------------------------------------------------------------------------
|
| Here is where you can register web routes for your application. These
| routes are loaded by the RouteServiceProvider within a group which
| contains the "web" middleware group. Now create something great!
|
*/

/*Route::get('/', function () {
    [userController::class, 'allCountries'];
    [userController::class, 'allCities'];
    return view('home');
})->name('home');*/

Route::resource('/rest', 'App\Http\Controllers\CountryController')->names('rest');

Route::get('/about', function () {
    return view('about');
});

Route::get('/contact', function () {
    return view('contact');
});

Route::get('/', [userController::class, 'allCountries'])->name('home');

Route::post('/choice', [userController::class, 'choiceCountry'])->name('choice');

//Route::get('/cities', [userController::class, 'allCities'])->name('cities');

Route::post('/contact/submit', [userController::class, 'submit'])->name('sub');

Route::get('/login', function () {
    return view('login');
});


