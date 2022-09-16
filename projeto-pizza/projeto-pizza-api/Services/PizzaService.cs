using projeto_pizza_api.DTO;
using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;

namespace projeto_pizza_api.Services
{

    /// <summary>
    /// Regra de Negocio fica na camada de Servico
    /// </summary>
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository<PizzaModel> _pizzaRepository;

        public PizzaService(IPizzaRepository<PizzaModel> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public int Add(PizzaPostDto pizzaPostDto)
        {
            if (pizzaPostDto.Descricao.Length <= 5)
            {
                throw new Exception("Pizza com poucos caracteres");
            }

            var model = new PizzaModel { Descricao = pizzaPostDto.Descricao, Valor = pizzaPostDto.Valor };
            return _pizzaRepository.Add(model);
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

        public PizzaMaisCaraGetDto GetMaxValue()
        {
            List<PizzaModel> pizzaModel = _pizzaRepository.GetAll().ToList();

            var valorMaximoPizza = pizzaModel.Select(s => s.Valor).Max();

            var pizzaMax = pizzaModel
                                .GroupBy(g => g.Valor)
                                .Where(w => w.Key == valorMaximoPizza)
                                .Select(s =>
                                        new PizzaMaisCaraGetDto(
                                            s.FirstOrDefault()!.Id,
                                            s.FirstOrDefault()!.Descricao,
                                            s.FirstOrDefault()!.Valor)
                                    ).FirstOrDefault()!;

            return pizzaMax;
        }

        public PizzaMaisBarataGetDto GetMinValue()
        {
            List<PizzaModel> pizzaModel = _pizzaRepository.GetAll().ToList();

            var valorMinimoPizza = pizzaModel.Select(s => s.Valor).Min();

            var pizzaMin = pizzaModel
                                .GroupBy(g => g.Valor)
                                .Where(w => w.Key == valorMinimoPizza)
                                .Select(s =>
                                        new PizzaMaisBarataGetDto(
                                            s.FirstOrDefault()!.Id,
                                            s.FirstOrDefault()!.Descricao,
                                            s.FirstOrDefault()!.Valor)
                                    ).FirstOrDefault()!;

            return pizzaMin;
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
}
