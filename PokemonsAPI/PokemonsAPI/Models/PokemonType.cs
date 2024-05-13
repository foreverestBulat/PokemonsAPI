namespace PokemonsAPI.Models;

public class PokemonType : Base
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string TextColor { get; set; }
    public ICollection<Pokemon> Pokemons { get; set; }
    public ICollection<PokemonDetails>? PokemonsDetails { get; set; }
    public virtual ICollection<Move>? Moves { get; set; }
}
