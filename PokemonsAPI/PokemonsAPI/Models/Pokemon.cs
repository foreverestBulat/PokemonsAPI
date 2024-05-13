namespace PokemonsAPI.Models;

public class Pokemon : Base
{
    public string Name { get; set; }
    public string Image { get; set; }
    public PokemonDetails Details { get; set; }
    public virtual ICollection<PokemonType>? Types { get; set; }
}
