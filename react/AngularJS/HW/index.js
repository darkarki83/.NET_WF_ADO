const PORT  = 80;
const HOST = "localhost";

const http = require( 'http' );
const fs = require( 'fs' );

http.createServer( serverCore )
.listen( PORT, HOST, () => {
    console.log("Server Listen port " + PORT)
});


function serverCore( request, response) {

 
    var url = decodeURI(request.url.substr( 1 )); // URL без первого слеша и декодированый %D1% -> я
    //var method = request.method.toUpperCase();
    //console.log(method + ' ' + url);

    if(fs.existsSync(url)) { //url - имя существуюцива файла
        pipe(url, "text/html", response);
    }
        switch( url ) {
            case '' :
                url = 'hw3.html';
            case 'hw3.html' :
                pipe(url, "text/html", response)
                break;
            case 'news' :
                response.writeHead( 200,            // 200 this is ok
                    {               // заголовки - JSON {name: value, ...}
                        "Content-Type": "application/json",
                        "Conecion":"close"
                    }              
                );
                response.end( JSON.stringify(
                    [
                        {id : 1, "short_title" :"news 1", "content": "The new 1"},
                        {id : 3, "short_title" :"news 12", "content": "The new 12"},
                        {id : 5, "short_title" :"news 15", "content": "The new 15"}
                        
                    ]
                ));
            break;
            
        }
          
}

async function pipe(url, type, response, code = 200){

    var f = fs.createReadStream(url);
    f.on('open', () => {
        response.writeHead( // send status
            code,            // 200 this is ok
            {               // заголовки - JSON {name: value, ...}
                "Content-Type": type,
                "Conecion":"close"
            }              
        );
        f.pipe( response );
    });
}