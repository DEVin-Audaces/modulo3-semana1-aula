using Microsoft.EntityFrameworkCore;

namespace projeto_pizza_api.DataBase
{
    public class PizzaDBContext : DbContext
    {
        public PizzaDBContext(DbContextOptions<PizzaDBContext> options) : base(options)
        {

        }

        public DbSet<PizzaModel> Pizza { get; set; }
    }
}
