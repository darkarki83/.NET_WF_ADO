<?php

use Illuminate\Support\Facades\Route;



Route::get('/', function () {
    return view('home');
})->name('home');

Route::get('/about', function () {
    return view('about');
})->name('about');

Route::get('/contact', function () {
    return view('contact');
})->name('contact');

Route::post('/contact/submit', [App\Http\Controllers\ContactController::class, 'store']
)->name('contact_form');

Route::get('/index', [App\Http\Controllers\ContactController::class, 'index']
)->name('contact_index');

Route::get('/index/{id}', [App\Http\Controllers\ContactController::class, 'show']
)->name('contact_index_show');

Route::get('/index/{id}/edit', [App\Http\Controllers\ContactController::class, 'edit']
)->name('contact_index_edit');

Route::post('/index/{id}/edit', [App\Http\Controllers\ContactController::class, 'update']
)->name('contact_index_update');

Route::get('/index/{id}/destroy', [App\Http\Controllers\ContactController::class, 'destroy']
)->name('contact_index_destroy');
