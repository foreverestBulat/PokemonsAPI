using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Data;
using PokemonsAPI.Models;
using System.Security.Cryptography.X509Certificates;


namespace PokemonsAPI.Controllers;

public class PokemonController : ApiControllerBase
{
    private readonly ApplicationDbContext _context;
    public PokemonController(ApplicationDbContext context)
    {
        _context = context;
    }

    //[HttpGet("Pokemons")]
    //public async Task<List<ModelPokemon>> SearchPokemons(string name)
    //{
    //    _context.Pokemons.Where(e => e.Name.Contains(name));
    //}


    [EnableCors("AllowOrigin")]
    //[EnableCors("http://localhost:5173")]
    [HttpGet("Pokemons")]
    public List<ModelPokemon> GetListPokemons(int index, int count, string name=null)
    {
        var pokemons = new List<ModelPokemon>();
        if (name is null)
            foreach (var pokemonEntity in _context.Pokemons.Include(e => e.Types).Skip(index).Take(count))
                pokemons.Add(new ModelPokemon(pokemonEntity));
        else
            foreach (var pokemonEntity in _context.Pokemons.Where(e => e.Name.Contains(name)).Include(e => e.Types).Skip(index).Take(count))
                pokemons.Add(new ModelPokemon(pokemonEntity));
        return pokemons;
    }

    public class ModelPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<string> Types { get; set; }

        public ModelPokemon(Pokemon pokemon)
        {
            Id = pokemon.Id;
            Name = pokemon.Name;
            Image = pokemon.Image;
            Types = pokemon.Types?.Select(e => e.Name).ToList();
        }
    }

    [HttpGet("Pokemon")]
    public async Task<ModelPokemonDetails?> GetPokemon(int index)
    {
        var details = await 
            _context
            .PokemonsDetails
            .Include(e => e.Pokemon)
            .Include(e => e.Stats)
            .Include(e => e.Abilities)
            .Include(e => e.Moves)
            .Include(e => e.Types)
            .FirstOrDefaultAsync(e => e.Pokemon.Id == index);
        return new ModelPokemonDetails(details);
    }

    public class ModelPokemonDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public string Image { get; set; }
        public virtual List<string> Types { get; set; }
        public virtual List<MoveName> Moves { get; set; }
        public virtual List<string> Abilities { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpecialAttack { get; set; }
        public int SpecialDefense { get; set; }
        public int Speed { get; set; }

        public ModelPokemonDetails(PokemonDetails details)
        {
            Id = details.Pokemon.Id;
            Name = details.Name;
            Height = details.Height;
            Weight = details.Weight;
            Image = details.Pokemon.Image;
            Types = details.Types?.Select(t => t.Name).ToList();
            Moves = details.Moves?.Select(t => new MoveName(t.Name, t.Type?.Name )).ToList();
             
            Abilities = details.Abilities?.Select(t => t.Name).ToList();
            Hp = details.Stats.Hp;
            Attack = details.Stats.Attack;
            Defense = details.Stats.Defense;
            SpecialAttack = details.Stats.SpecialAttack;
            SpecialDefense = details.Stats.SpecialDefense;
            Speed = details.Stats.Speed;
        }

       public record class MoveName(string Name, string TypeName);
    }
}
