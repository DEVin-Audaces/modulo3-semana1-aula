using Microsoft.EntityFrameworkCore;
using projeto_pizza_api.DataBase;

namespace projeto_pizza_tests
{
    public class TestPizzaDbContextFactory : IDbContextFactory<PizzaDBContext>
    {
        private readonly DbContextOptions<PizzaDBContext> _opitions;

        public TestPizzaDbContextFactory(string databaseName = "InMemoryTest")
        {
            _opitions = new DbContextOptionsBuilder<PizzaDBContext>()
                                .UseInMemoryDatabase(databaseName)
                                .Options;
        }

        public PizzaDBContext CreateDbContext()
        {
            return new PizzaDBContext(_opitions);
        }
    }
}