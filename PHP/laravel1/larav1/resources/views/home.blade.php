@extends('layouts.app')

@section('title-block')
    Home page
@endsection

@section('content')
    <h1>Home</h1>
@endsection

@section('aside')  <!--дополнительный параметр-->
    @parent
    <p>dop text</p>
@endsection
