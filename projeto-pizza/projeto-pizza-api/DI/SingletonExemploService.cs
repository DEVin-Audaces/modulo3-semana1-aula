namespace projeto_pizza_api
{
    public class SingletonExemploService : ISingletonExemploService
    {
        private int _contador = 1;

        public string Contador()
        {
            _contador++;
            return $"Número Contador da {nameof(SingletonExemploService)} {_contador}";
        }
    }
}
