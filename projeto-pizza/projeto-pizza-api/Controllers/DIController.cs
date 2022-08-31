using Microsoft.AspNetCore.Mvc;
using projeto_pizza_api.DI;

namespace projeto_pizza_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DIController : ControllerBase
    {
        private readonly ILogger<DIController> _logger;
        private readonly ITransientExemploService _transientExemploService;
        private readonly IScopedExemploService _scopeExemploService;
        private readonly ISingletonExemploService _singletonExemploService;
        private readonly ITesteService _testeService;

        public DIController(
            ITransientExemploService transientExemploService,
            IScopedExemploService scopeExemploService,
            ISingletonExemploService singletonExemploService,
            ITesteService testeService,
            ILogger<DIController> logger)
        {

            _transientExemploService = transientExemploService;
            _scopeExemploService = scopeExemploService;
            _singletonExemploService = singletonExemploService;
            _testeService = testeService;
            _logger = logger;
        }

        [HttpGet(Name = "Get")]
        public string Get()
        {
            var localTransient1 = _transientExemploService.Contador();
            var localTransient2 = _transientExemploService.Contador();

            _testeService.NovoMetodo();

            var scopeLocal1 = _scopeExemploService.Contador();
            var scopeLocal2 = _scopeExemploService.Contador();

            _testeService.NovoMetodo();

            var singletonLocal1 = _singletonExemploService.Contador();
            var singletonLocal2 = _singletonExemploService.Contador();

            _testeService.NovoMetodo();
            
            var returns = @$"
                             {localTransient1}
                             {localTransient2}
                             {scopeLocal1}
                             {scopeLocal2}
                             {singletonLocal1}
                             {singletonLocal2}";

            return returns;
        }
    }
}