using Microsoft.EntityFrameworkCore;
using projeto_pizza_api.Models;

namespace projeto_pizza_api.DataBase
{
    public class PizzaDBContext : DbContext
    {
        public PizzaDBContext(DbContextOptions<PizzaDBContext> options) : base(options)
        {
        }

        public DbSet<PizzaModel> Pizza { get; set; }
        public DbSet<PizzaGuidModel> PizzaGuid { get; set; }
    }
}
