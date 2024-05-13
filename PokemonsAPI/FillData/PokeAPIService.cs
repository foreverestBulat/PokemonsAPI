using FillData.ClassesForDeserialization;
using Newtonsoft.Json;
using PokemonsAPI.Data;
using PokemonsAPI.Models;
using System.Linq;
using System.Net.Http.Headers;

namespace FillData;

public static class PokeAPIService
{
    private static HttpClient _client;
    private static HttpResponseMessage response;
    private static string responseBody;
    private static string resultString;

    public static void Configure()
    {
        _client = new HttpClient();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "API_KEY");
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        resultString = "";
    }

    public static async Task AddPokemonsAndRelatedEntities(this ApplicationDbContext context, string url= "https://pokeapi.co/api/v2/pokemon?offset=0&limit=45")
    {
        var result = JsonConvert.DeserializeObject<ResultList>(await GetBody(url));

        var pokemons = new List<Pokemon>();
        var pokemonsDetails = new List<PokemonDetails>();
        var stats = new List<PokemonStats>();
        foreach (var item in result.Results)
        {
            response = await _client.GetAsync(item.Url);
            responseBody = await response.Content.ReadAsStringAsync();
            var resultPokemon = JsonConvert.DeserializeObject<PokemonPokeAPI>(responseBody);
            Console.WriteLine(resultPokemon.Name);

            var types = context.PokemonTypes.Where(e => resultPokemon.Types.Select(t => t.Type.Name).Contains(e.Name));
            var moves = context.Moves.Where(e => resultPokemon.Moves.Select(m => m.Move.Name).Contains(e.Name));
            var abilities = context.Abilities.Where(e => resultPokemon.Abilities.Select(a => a.Ability.Name).Contains(e.Name));

            var pokemon = new Pokemon()
            {
                Name = resultPokemon.Name,
                Image = resultPokemon.Sprites.front_default,
                Details = new PokemonDetails()
                {
                    Name = resultPokemon.Name,
                    Height = resultPokemon.Height,
                    Weight = resultPokemon.Weight,
                    Stats = new PokemonStats()
                    {
                        Hp = resultPokemon.Stats[0].base_stat,
                        Attack = resultPokemon.Stats[1].base_stat,
                        Defense = resultPokemon.Stats[2].base_stat,
                        SpecialAttack = resultPokemon.Stats[3].base_stat,
                        SpecialDefense = resultPokemon.Stats[4].base_stat,
                        Speed = resultPokemon.Stats[5].base_stat
                    },
                    Types = types.ToList(),
                    Moves = moves.ToList(),
                    Abilities = abilities.ToList(),
                },
                Types = types.ToList(),
            };
            context.Pokemons.Add(pokemon);
        }
        resultString += "Pokemons Filled!\n";
    }

    public static async Task AddAbilities(this ApplicationDbContext context, string url="https://pokeapi.co/api/v2/ability?limit=50") // 367
    {
        var result = JsonConvert.DeserializeObject<ResultList>(await GetBody(url));

        var abilities = new List<Ability>();
        foreach (var item in result.Results)
        {
            response = await _client.GetAsync(item.Url);
            responseBody = await response.Content.ReadAsStringAsync();
            var resultAbility = JsonConvert.DeserializeObject<AbilityPokeAPI>(responseBody);
            Console.WriteLine(resultAbility.Name);
            context.Abilities.Add(new Ability() { Name = item.Name });
        }
        resultString += "Abilities Filled!\n";
    }

    public static async Task AddMoves(this ApplicationDbContext context, string url= "https://pokeapi.co/api/v2/move?limit=100")
    {
        var result = JsonConvert.DeserializeObject<ResultList>(await GetBody(url));

        var moves = new List<Move>();
        foreach (var item in result.Results)
        {
            response = await _client.GetAsync(item.Url);
            responseBody = await response.Content.ReadAsStringAsync();
            var resultMove = JsonConvert.DeserializeObject<MovePokeAPI>(responseBody);
            Console.WriteLine(resultMove.Name);
            context.Moves.Add(new Move() { Name = item.Name });
        }
        resultString += "Moves Filled!\n";
    }

    public static async Task AddPokemonTypes(this ApplicationDbContext context, string url= "https://pokeapi.co/api/v2/type?limit=100")
    {
        var result = JsonConvert.DeserializeObject<ResultList>(await GetBody(url));

        var types = new List<TypePokeAPI>();
        foreach (var item in result.Results)
        {
            response = await _client.GetAsync(item.Url);
            responseBody = await response.Content.ReadAsStringAsync();
            var resultType = JsonConvert.DeserializeObject<TypePokeAPI>(responseBody);
            Console.WriteLine(resultType.Name);
            context.PokemonTypes.Add(new PokemonType() { Name = item.Name });
        }
        resultString += "PokemonTypes Filled!\n";
    }

    public static async Task SaveChangesPokeAPIAsync(this ApplicationDbContext context)
    {
        await context.SaveChangesAsync();
        Console.WriteLine(resultString);
    }

    private static async Task<string> GetBody(string url)
    {
        response = await _client.GetAsync(url);
        return await response.Content.ReadAsStringAsync();
    }
}

