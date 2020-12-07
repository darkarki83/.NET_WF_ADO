
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>Travel Agency</title>
    <!-- Bootstrap -->
    <link rel="stylesheet" href="/css/app.css">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
</head>
<body>
<div class="container" >
    <div class="row">
        <header class="col-sm-12 col-md-12 col-lg-12">
            @include('inc.login')
        </header>
    </div>

    <div class="row">
        <nav class="col-sm-12 col-md-12 col-lg-12 head">
            @include('inc.header')
        </nav>
    </div>

    @if(Request::is('/'))
        @include('inc.hero')
    @endif
    <div class="row">
        <section class="col-sm-12 col-md-12 col-lg-12">
                    @yield('content')

            <?php
            /*if(isset($_GET['page']))
            {
                if($page==1 && isset($_SESSION['ruser'])) include_once("pages/tours.php");
                if($page==2 && isset($_SESSION['ruser'])) include_once("pages/comments.php");
                if($page==3) include_once("pages/registration.php");
                if($page==4 && isset($_SESSION['ruser'])) include_once("pages/admin.php");
                if($page==5 && isset($_SESSION['radmin']))
                    include_once("pages/private.php");
            }*/
            ?>
        </section>
    </div>

</div>
<!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>
<!-- Include all compiled plugins (below), or include individual files as needed -->
<script src="js/bootstrap.min.js"></script>
</body>
</html>
