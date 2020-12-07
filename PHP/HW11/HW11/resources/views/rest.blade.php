@extends('layouts.app')

@section('title')
    Home page
@endsection

@section('content')
        @csrf


        <select name="contry_id" id="contry_id" class="form-control input-sm" >
            <option value="" disabled selected>Choice option</option>
            @foreach($date as $publication)
                <option value="{{ $publication->id }}">
                    {{ $publication->country }}</option>
            @endforeach
            @if(isset($_GET['contry_id']))
                <div>selected</div>
            @endif
        </select>

        <select name="City">
            <option value="" disabled selected>Choose option</option>


            @if(isset($_REQUEST['contry_id']))
                @foreach($city as $el)
                        @if($el->country_fk == $_REQUEST['contry_id'])
                            <option  value="{{ $el->id }}" >{{ $el->city }}</option>
                        @endif
                @endforeach
            @endif
        </select>


        @endsection

        @section('aside')
            @parent
            <p>More information</p>
@endsection

