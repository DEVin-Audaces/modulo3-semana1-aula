using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projeto_pizza_api.DTO;
using projeto_pizza_api.Services;

namespace projeto_pizza_api.Controllers
{
    /// <summary>
    /// Na controller Try Catch, Gestao de Logs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FiltroController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public FiltroController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet("PizzaMaisCara")]
        public ActionResult<PizzaMaisCaraGetDto> PizzaMaisCara()
        {
            try
            {
                return Ok(_pizzaService.GetMaxValue());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpGet("PizzaMaisBarata")]
        public ActionResult<PizzaMaisBarataGetDto> PizzaMaisBarata()
        {
            try
            {
                return Ok(_pizzaService.GetMinValue());
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
