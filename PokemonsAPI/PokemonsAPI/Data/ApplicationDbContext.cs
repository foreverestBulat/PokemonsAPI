using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Models;
using PokemonsAPI.Services;
using System.Reflection;
//using FillData;

namespace PokemonsAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
        : base(options)
    {
        
    }

    public DbSet<Pokemon> Pokemons => Set<Pokemon>();
    public DbSet<PokemonDetails> PokemonsDetails => Set<PokemonDetails>();
    public DbSet<Move> Moves => Set<Move>();
    public DbSet<Ability> Abilities => Set<Ability>();
    public DbSet<PokemonStats> PokemonsStats => Set<PokemonStats>();
    public DbSet<PokemonType> PokemonTypes => Set<PokemonType>();


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        builder.Entity<Pokemon>()
            .HasOne(e => e.Details)
            .WithOne(e => e.Pokemon)
            .HasForeignKey<PokemonDetails>("PokemonId")
            .IsRequired(true);

        builder.Entity<PokemonDetails>()
            .HasOne(e => e.Stats)
            .WithOne(e => e.Details)
            .HasForeignKey<PokemonStats>("PokemonDetailsId")
            .IsRequired(true);

        builder.Entity<Pokemon>()
            .HasMany(e => e.Types)
            .WithMany(e => e.Pokemons);

        builder.Entity<PokemonDetails>()
            .HasMany(e => e.Types)
            .WithMany(e => e.PokemonsDetails);

        builder.Entity<PokemonDetails>()
            .HasMany(e => e.Moves)
            .WithMany(e => e.PokemonsDetails);

        builder.Entity<PokemonDetails>()
            .HasMany(e => e.Abilities)
            .WithMany(e => e.PokemonsDetails);

        builder.Entity<Ability>()
            .Property(e => e.Color)
            .IsRequired(false);

        builder.Entity<Ability>()
            .Property(e => e.TextColor)
            .IsRequired(false);

        builder.Entity<Move>()
            .Property(e => e.Color)
            .IsRequired(false);

        builder.Entity<Move>()
            .Property(e => e.TextColor)
            .IsRequired(false);

        builder.Entity<PokemonType>()
            .Property(e => e.Color)
            .IsRequired(false);

        builder.Entity<PokemonType>()
            .Property(e => e.TextColor)
            .IsRequired(false);

        //builder.Entity<Move>()
        //    .HasOne(e => e.Type)
        //    .WithMany(e => e.Moves)
        //    .HasForeignKey("TypeId")
        //    .IsRequired(false);
        builder.Entity<PokemonType>()
            .HasMany(e => e.Moves)
            .WithOne(e => e.Type)
            .HasForeignKey("TypeId")
            .IsRequired(false);
        
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
