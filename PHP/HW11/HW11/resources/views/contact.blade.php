@extends('layouts.app')

@section('title')
    Contact
@endsection

@section('content')
    <h1>Contact</h1>

    <form action="{{ route('sub') }}" method="post">
        @csrf
        <div>
            <label for="name">Name</label>
            <input type="text" name="name" placeholder="Write name" id="name" class="form-control"></input>
        </div>
        <div>
            <label for="pass">Password</label>
            <input type="password" name="password" placeholder="Write password" id="pass" class="form-control"></input>
        </div>
        <div style="margin-top: 5%">
            <button style="width: 30%" type="submit" class="btn btn-success">Login</button>
        </div>
    </form>
@endsection
