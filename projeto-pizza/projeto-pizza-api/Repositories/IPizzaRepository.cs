namespace projeto_pizza_api.Repositories
{

    public interface IPizzaRepository<TEntity> : IEntity<TEntity>
    {
        IList<TEntity> BuscarPorMaiorPreco();
    }
}
