@extends('layouts.app')

@section('title-block')
   Edit message
@endsection

@section('content')
    <h1>Edit message</h1>

    <form action="{{ route('contact_index_update' , $item->id ) }}" method="post">
        @csrf
        <div class="form-group">
            <label for="name">Name</label>
            <input id="name" value="{{$item->name}}" class="form-control" type="text" name="name" placeholder="write
            name">
        </div>
        <div class="form-group">
            <label for="email">Email</label>
            <input id="email" value="{{$item->email}}" class="form-control" type="text" name="email" placeholder="write email">
        </div>
        <div class="form-group">
            <label for="subject">Message subject</label>
            <input id="subject" value="{{$item->subject}}" class="form-control" type="text" name="subject"
                   placeholder="Message subject">
        </div>
        <div class="form-group">
            <label for="message">Message</label>
            <textarea id="message" class="form-control" name="message"
            >{{$item->message}}</textarea>
        </div>
        <button type="submit" class="btn btn-success">Edit</button>
    </form>

@endsection
