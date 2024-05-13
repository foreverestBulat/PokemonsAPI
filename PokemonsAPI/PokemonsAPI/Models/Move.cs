namespace PokemonsAPI.Models;

public class Move : Base
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string TextColor { get; set; }
    public PokemonType Type { get; set; }
    public ICollection<PokemonDetails> PokemonsDetails { get; set; }
}
