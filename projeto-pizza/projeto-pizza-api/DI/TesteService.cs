namespace projeto_pizza_api.DI
{
    public class TesteService : ITesteService
    {
        private readonly ITransientExemploService _transientExemploService;
        private readonly IScopedExemploService _scopeExemploService;
        private readonly ISingletonExemploService _singletonExemploService;

        public TesteService(
            ITransientExemploService transientExemploService,
            IScopedExemploService scopeExemploService,
            ISingletonExemploService singletonExemploService)
        {

            _transientExemploService = transientExemploService;
            _scopeExemploService = scopeExemploService;
            _singletonExemploService = singletonExemploService;
        }

        public void NovoMetodo()
        {
            _transientExemploService.Contador();
            _scopeExemploService.Contador();
            _singletonExemploService.Contador();
        }
    }
}
