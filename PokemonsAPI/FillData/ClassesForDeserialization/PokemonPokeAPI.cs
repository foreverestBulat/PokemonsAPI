namespace FillData.ClassesForDeserialization;

public class PokemonPokeAPI
{
    public int Id { get; set; }
    public List<ItemPokeProperty> Abilities { get; set; }
    public List<ItemPokeProperty> Moves { get; set; }
    public List<ItemPokeProperty> Types { get; set; }

    public string Name { get; set; }
    public Sprites Sprites { get; set; }
    public string Url { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
    public List<StatsPokeAPI> Stats { get; set; }
}
