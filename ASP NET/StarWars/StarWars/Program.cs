using StarWars.Model;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWars
{
    class Program
    {
        private static readonly string apiUrl = "https://swapi.dev/api/people/1/";

        static async Task Main()
        {
            HttpResponseMessage httpResponse;

            //  нежно при старом протоколе или  
            //string httpJsonResponse;

            //
            // Асинхронно посылаем GET-запрос к RESTful-сервису
            //

            // Отправляем HTTP-запрос
            using (HttpClient httpClient = new HttpClient())
            {
                // Отправляем GET-запрос
                httpResponse = await httpClient.GetAsync(apiUrl);

                // Просто на посмотреть весь ответ ввиде строки
                /*
                 * 
                // Вынимаем тело HTTP-ответа в виде строки. Ответ будет в "минифицированном" JSON-формате.
                httpJsonResponse = await httpResponse.Content.ReadAsStringAsync();
                // Выводим "минифицированный" JSON-ответ
                Console.WriteLine($"{httpJsonResponse}\n");
                
                 */
            }

            var person = await JsonSerializer.DeserializeAsync<Person>(
                await httpResponse.Content.ReadAsStreamAsync());

            Console.WriteLine(person); // only for a look




            //
            // Сериализуем объект personLuke типа Person в "красивый" JSON-формат
            //
            // Собственно, сериализация
            string goodFullJson = JsonSerializer.Serialize<Person>(
                person, new JsonSerializerOptions { WriteIndented = true });

            // Выводим "красивое" JSON File 
            Console.WriteLine(goodFullJson);

        }
    }
}
