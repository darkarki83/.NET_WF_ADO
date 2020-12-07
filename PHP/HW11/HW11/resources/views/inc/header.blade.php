<div class="d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 bg-white border-bottom shadow-sm">
    <h5 class="my-0 mr-md-auto font-weight-normal">Wind rose</h5>
    <nav class="my-2 my-md-0 mr-md-3">
        <a class="p-2 text-dark" href="{{ route('home') }}">Tours</a>
        <a class="p-2 text-dark" href="comments">Comments</a>
        <a class="p-2 text-dark" href="registration">Registration</a>
        <a class="p-2 text-dark" href="rest">rest</a>
        <?php
        //@if(isset($_SESSION['radmin']))?>
            @if(Request::is('/privet'))
                <a class="p-2 text-dark active" href="private">Private</a>
            @endif



    </nav>
    <a class="btn btn-outline-primary" href="admin">Admin</a>
</div>
