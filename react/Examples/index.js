// local server

const http = require( 'http' );
const fs = require( 'fs' );

                    // HOST:PORT - Endpoint (канечный пользователь)
const PORT = "80";        // ID приложения
const HOST = '127.0.0.1'; // Имя узла либо его IP (This is name) 

// Старт сервера - прослушка порта

http
.createServer( serverCore )   // функция запускается при обращение к серверу(она ниже)
.listen( PORT, HOST, () => {  //Старт прослушки - основная работа сервера
    console.log("Server listen port" + PORT);
});

// Серверная фенкции - ядро сервера аналез запроса(request), и подготовка ответа (response) 
function serverCore( request, response) {

    //console.log(request);
    var url = decodeURI(request.url.substr( 1 )); // URL без первого слеша и декодированый %D1% -> я
    var method = request.method.toUpperCase();
    console.log(method + ' ' + url);

    //problem а все вопросы отдает index.html
    //решение
    //1) если запрос файла (exists) - отправляем его
    //2) белый список - если запрос из разрешоных файлов - отправить
    //3) черный спиок - все кроме указаных

    /*1) exists
    if(fs.existsSync(url)) { //url - имя существуюцива файла
        pipe();
    }
    //3) черный спиок
    if(url != 'config.json') {  // все кроме config.json
        pipe();
    }*/
    //2) белый список
    switch( url ) {
        case 'index.css' :
            pipe('index.css', "text/css", response);
            break;
        case '' :
        case 'index.html' :
            pipe('index.html', "text/html", response)
            break;
        case 'favicon.ico' :
                pipe('images.jpg', "image/png", response)
                break;
        case 'picture' :
                pipe('picture.html', "text/html", response)
                break;
        default:
            pipe('404.html', "text/html", response, 404)
            break;
    }
  
    //response.end('hello world');
    //вместо отдаем файл
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


}

/*

1. Запрос / ответ = одна строка
запрос: GET / HTTP/1.1
ответ: HTTP/1.1 200 ok

2.  Заголовки Имя: Значение
Host localhost,
connection: 'keep-alive',
2.1 каждый заголовот с новой строчки и конец заголовков пусая строка

3. Тело покета(Не обязательно)
<!Document html />
*/