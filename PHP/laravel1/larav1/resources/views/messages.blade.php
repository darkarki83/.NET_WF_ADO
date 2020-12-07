@extends('layouts.app')

@section('title-block')
    All messages
@endsection

@section('content')
    @foreach($db as $item)
        <div class="alert alert-info">
            <h3> {{ $item->name }}</h3>
            <p> {{ $item->email }}</p>
            <p><small> {{ $item->created_at }}</small></p>
            <a href="{{ route('contact_index_show',  $item->id)}}"><button class="btn btn-warning">More
                    information</button></a>
        </div>
    @endforeach
@endsection

