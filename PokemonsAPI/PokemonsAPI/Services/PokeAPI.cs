using System.Net.Http.Headers;

namespace PokemonsAPI.Services;

public class PokeAPI
{
    public async static void GetData()
    {
        // Создание экземпляра HttpClient
        HttpClient client = new HttpClient();

        // Установка заголовков запроса
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API_KEY");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Отправка GET-запроса
        HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/move?offset=0&limit=100");

        // Получение ответа
        string responseBody = await response.Content.ReadAsStringAsync();
        Console.WriteLine();
        // Анализ данных ответа
        // ...
        //context.SaveChanges();
        Console.WriteLine("Seeded data to the Database");
    }
}
