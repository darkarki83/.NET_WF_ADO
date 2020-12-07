@extends('layouts.app')

@section('title-block')
    Home page
@endsection

@section('content')
    <h1>contact</h1>

    <form action="{{ route('contact_form') }}" method="post">
        @csrf
        <div class="form-group">
            <label for="name">Name</label>
            <input id="name" class="form-control" type="text" name="name" placeholder="write name">
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input id="email" class="form-control" type="text" name="email" placeholder="write email">
        </div>
        <div class="form-group">
            <label for="subject">Message subject</label>
            <input id="subject" class="form-control" type="text" name="subject" placeholder="Message subject">
        </div>
        <div class="form-group">
            <label for="message">Message</label>
            <textarea id="message" class="form-control" name="message" ></textarea>
        </div>
        <button type="submit" class="btn btn-success">Send</button>
    </form>

@endsection
