@extends('layouts.app')

@section('title')
    Home page
@endsection

@section('content')
    <form action="{{ route('home') }}" method="post">
        @csrf
        <select name="Country">
            <option value="0" disabled selected>Choose option</option>
            @if(isset($date))
                @foreach($date as $el)
                    <option  value="{{ $el->id }}" >{{ $el->country }}</option>
                @endforeach
            @endif
        </select>
        <select name="City">
            <option value="" disabled selected>Choose option</option>

            @if(isset($city))
                @foreach($city as $el)
                    <option  value="{{ $el->id }}" >{{ $el->city }}</option>
                @endforeach
            @endif
        </select>


@endsection

@section('aside')
    @parent
    <p>More information</p>
@endsection

