using PokemonsAPI.Models;
using System.Net.Http.Headers;

namespace PokemonsAPI.Data;

public static class SeedData
{
    public static void PopulateDb(IApplicationBuilder app)
    {
        
        //using var serviceScope = app.ApplicationServices.CreateScope();
        //AddInitialData(serviceScope.ServiceProvider.GetService<ApplicationDbContext>()!);
    }

    public async static void AddInitialData(ApplicationDbContext context)
    {
        var types = new Dictionary<string, List<string>>{
            { "normal", new List<string>(){ "#A52A2A", "white" } },
            { "fighting", new List<string>() { "#FFA500", "white" } },
            { "flying", new List<string>() { "#5F9EA0", "white" } },
            { "poison", new List < string >() { "#9400D3", "white" } },
            { "ground", new List<string>() { "#D2691E", "white" } },
            { "rock", new List < string >() { "#8B4513", "white" } },
            { "bug", new List<string>() { "#006400", "white" } },
            { "ghost", new List < string >() { "#483D8B", "white" } },
            { "steel", new List < string >() { "#00FF7F", "white" } },
            { "fire", new List < string >() { "#FF0000", "white" } },
            { "water", new List < string >() { "#0000FF", "white" } },
            { "grass", new List < string >() { "#008000", "white" } },
            { "electric", new List < string >() { "#FFFF00", "black" } },
            { "phychic", new List < string >() { "#DB7093", "black" } },
            { "ice", new List < string >() { "#ADD8E6", "white" } },
            { "dragon", new List < string >() { "#00FFFF", "white" } },
            { "dark", new List < string >() { "#000000", "white" } },
            { "fairy", new List < string >() { "#DC143C", "white" } },
            { "unknown", new List < string >() { "#A9A9A9", "white" } },
            { "shadow", new List < string >() { "#191970", "white" } },
        };

        var typesList = new List<PokemonType>();
        foreach (var type in types)
        {
            Console.WriteLine(type.Key);
            typesList.Add(new PokemonType()
            {
                Name = type.Key,
                Color = type.Value[0],
                TextColor = type.Value[1]
            });
        }

        context.Add(typesList);

        // Создание экземпляра HttpClient
        HttpClient client = new HttpClient();

        // Установка заголовков запроса
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API_KEY");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Отправка GET-запроса
        HttpResponseMessage response = await client.GetAsync("https://pokeapi.co/api/v2/move?offset=0&limit=100");

        // Получение ответа
        string responseBody = await response.Content.ReadAsStringAsync();

        // Анализ данных ответа
        // ...
        context.SaveChanges();
        Console.WriteLine("Seeded data to the Database");
    }
}
