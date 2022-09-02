using projeto_pizza_api.DTO;
using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;

namespace projeto_pizza_api.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository<PizzaModel> _pizzaRepository;

        public PizzaService(IPizzaRepository<PizzaModel> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public int Add(PizzaPostDto pizzaPostDto)
        {
            var model = new PizzaModel { Descricao = pizzaPostDto.Descricao, Valor = pizzaPostDto.Valor };
            _pizzaRepository.Add(model);

            return model.Id;
        }

        public bool Delete(int id)
        {
            return _pizzaRepository.Delete(id);
        }

        public IList<PizzaGetDto> GetAll()
        {
            var pizzaModel = _pizzaRepository.GetAll();
            List<PizzaGetDto> returns = new(pizzaModel.Select(lambdaExpressio => (PizzaGetDto)lambdaExpressio));
            return returns;
        }

        public bool Update(PizzaPutDto pizzaPutDto)
        {
            var model = new PizzaModel
            {
                Id = pizzaPutDto.Id,
                Descricao = pizzaPutDto.Descricao,
                Valor = pizzaPutDto.Valor
            };

            return _pizzaRepository.Update(model);
        }
    }

    public interface IPizzaService
    {
        int Add(PizzaPostDto pizzaPostDto);
        bool Update(PizzaPutDto pizzaPutDto);
        bool Delete(int id);
        IList<PizzaGetDto> GetAll();
    }
}
