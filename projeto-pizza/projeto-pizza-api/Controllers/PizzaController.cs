using Microsoft.AspNetCore.Mvc;
using projeto_pizza_api.DTO;
using projeto_pizza_api.Services;

namespace projeto_pizza_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public ActionResult<IList<PizzaGetDto>> Get()
        {
            try
            {
                return Ok(_pizzaService.GetAll());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpDelete("/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            try
            {
                return Ok(_pizzaService.Delete(id));
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }


        [HttpPost]
        public ActionResult<PizzaPostDto> Post(PizzaPostDto request)
        {
            try
            {
                var returns = _pizzaService.Add(request);
                return request;
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public ActionResult<bool> Put(PizzaPutDto request)
        {
            try
            {
                return _pizzaService.Update(request);
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
