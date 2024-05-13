namespace PokemonsAPI.Models;

public class Ability : Base
{
    public string Name { get; set; }
    public string Color { get; set; }
    public string TextColor { get; set; }
    public ICollection<PokemonDetails> PokemonsDetails { get; set; }
}
