namespace projeto_pizza_api
{
    public class TransientExemploService : ITransientExemploService
    {
        private int _contador;

        public string Contador()
        {
            _contador++;
            return $"Número Contador da {nameof(TransientExemploService)} {_contador}";
        }
    }
}
