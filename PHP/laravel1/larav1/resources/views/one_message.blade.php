@extends('layouts.app')


@section('content')
        <div class="alert alert-info">
            <h3> {{ $item->name }}</h3>
            <p> {{ $item->email }}</p>
            <p> {{ $item->subject }}</p>
            <p> {{ $item->message }}</p>
            <p><small> {{ $item->created_at }}</small></p>
            <a href="{{ route('contact_index_edit',  $item->id)}}"><button class="btn btn-primary">edit</button></a>
            <a href="{{ route('contact_index_destroy',  $item->id)}}"><button class="btn
            btn-danger">delete</button></a>

        </div>
@endsection

