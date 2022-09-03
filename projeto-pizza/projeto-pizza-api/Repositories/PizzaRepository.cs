using Microsoft.EntityFrameworkCore;
using projeto_pizza_api.DataBase;
using projeto_pizza_api.Models;

namespace projeto_pizza_api.Repositories
{
    public class PizzaRepository : IPizzaRepository<PizzaModel>
    {
        private readonly IDbContextFactory<PizzaDBContext> _dbContextFactory;

        public PizzaRepository(IDbContextFactory<PizzaDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public int Add(PizzaModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Add(model);
                context.SaveChanges();
            }

            return model.Id;
        }

        public IList<PizzaModel> BuscarPorMaiorPreco()
        {
            throw new NotImplementedException();
        }

        public bool Update(PizzaModel model)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Update(model);
                return context.SaveChanges() > 0;
            }
        }

        public bool Delete(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                context.Remove<PizzaModel>(new PizzaModel { Id = id });
                return context.SaveChanges() > 0;
            }
        }

        public IList<PizzaModel> GetAll()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return context.Pizza.ToList();
            }
        }
    }
}
