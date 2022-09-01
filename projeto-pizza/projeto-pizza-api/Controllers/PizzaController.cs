using Microsoft.AspNetCore.Mvc;
using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;

namespace projeto_pizza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private static List<PizzaDto> minhaLista = new();

        private readonly IPizzaRepository<PizzaModel> _pizzaRepository;

        public PizzaController(IPizzaRepository<PizzaModel> pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        [HttpGet]
        public IEnumerable<PizzaDto> Get()
        {
            return minhaLista; 
        }

        [HttpPost("post/{codigo}/{nome}")]
        public PizzaDto Post([FromRoute] int codigo, [FromRoute] string nome) 
        {
            var pizza = new PizzaDto(codigo) { Nome = nome };
            minhaLista.Add(pizza);

            _pizzaRepository.Add(new PizzaModel { Descricao = "TESTE", Valor = 10M });

            return pizza ;
        }

        [HttpPut("put/{nome}")]
        public PizzaDto Put([FromQuery] int codigo, [FromRoute] string nome)
        {
            var pizza = minhaLista.Where(w => w.Codigo == codigo).FirstOrDefault();
            pizza!.Nome = nome;
            return pizza;
        }
    }

    public record PizzaDto(int Codigo)
    {
        public string Nome { get; set; } = "";
        public bool Validar(string parametro) => Nome == parametro;
    }
}
