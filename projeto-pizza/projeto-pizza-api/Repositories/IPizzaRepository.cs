using Microsoft.EntityFrameworkCore;
using projeto_pizza_api.DataBase;
using projeto_pizza_api.Models;

namespace projeto_pizza_api.Repositories
{
    public interface IEntity<TModel>
    {
        int Add(TModel model);
        int Update(TModel model);
        int Delete(TModel model);
    }

    public interface IPizzaRepository<TEntity> : IEntity<TEntity>
    {
        IList<TEntity> BuscarPorMaiorPreco();
    }

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

        public int Delete(PizzaModel model)
        {
            throw new NotImplementedException();
        }

        public int Update(PizzaModel model)
        {
            throw new NotImplementedException();
        }
    }

    //TODO: Depois aplicar uma classe abrastct
    //public abstract class MinhaClasseAbstract<TContext> : class
    //{
    //    private readonly IDbContextFactory<TContext> _dbContextFactory;

    //    public MinhaClasseAbstract(TContext context)
    //    {
    //        _dbContextFactory = context;
    //    }
    //}
}
