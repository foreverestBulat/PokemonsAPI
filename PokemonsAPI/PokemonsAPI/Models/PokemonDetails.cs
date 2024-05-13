namespace PokemonsAPI.Models;

public class PokemonDetails : Base
{
    public Pokemon Pokemon { get; set; }
    public string Name { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public virtual ICollection<PokemonType> Types { get; set; }
    public virtual ICollection<Move> Moves { get; set; }
    public virtual ICollection<Ability> Abilities { get; set; }
    public PokemonStats Stats { get; set; }
}
