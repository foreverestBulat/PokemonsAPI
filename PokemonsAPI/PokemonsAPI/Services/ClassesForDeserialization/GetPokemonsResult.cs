namespace PokemonsAPI.Services.ClassesForDeserialization;

public class GetPokemonsResult
{
    public int Count { get; set; }
    public List<PokemonPokeAPI> Results { get; set; }
}
