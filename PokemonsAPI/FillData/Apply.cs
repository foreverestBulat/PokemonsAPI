using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FillData
{
    public static class Apply
    {
        public async static void Start(ApplicationDbContext context = null)
        {
            Console.WriteLine("start");
            if (context is null)
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql("Host=localhost;Port=5432;Database=PokemonAPI;Username=postgres;Password=subuhankulov;").Options;
                context = new ApplicationDbContext(options);
            }

            PokeAPIService.Configure();
            await context.AddPokemonsAndRelatedEntities();
            await context.AddAbilities();
            await context.AddMoves();
            await context.AddPokemonTypes();
            await context.SaveChangesPokeAPIAsync();
        }
    }
}
