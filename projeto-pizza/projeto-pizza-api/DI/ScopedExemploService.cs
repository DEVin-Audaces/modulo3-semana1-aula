namespace projeto_pizza_api
{
    public class ScopedExemploService : IScopedExemploService
    {
        private int _contador;

        public string Contador()
        {
            _contador++;
            return $"Número Contador da {nameof(ScopedExemploService)} {_contador}";
        }
    }
}
