namespace projeto_pizza_tests.Exemplos
{
    public class ExemploTests
    {
        [Fact(DisplayName = "Teste Calulo Xunit")]
        [Trait("Exemplo Trait XUNit", "Calculo precisa ser igual a 25")]
        public void Calculo_Soma_Dois_Numeros_Sucesso()
        {
            //Arrange
            int valorA = 10;
            int valorB = 15;

            //Act
            var soma = valorA + valorB;

            //Assert
            Assert.Equal(25, soma);

        }

        [Fact(DisplayName = "Teste Calulo Xunit")]
        [Trait("Exemplo Trait XUNit", "Calculo precisa ser diferente de 25")]
        public void Calculo_Soma_Dois_Numeros_Sucesso_ComErro()
        {
            //Arrange
            int valorA = 10;
            int valorB = 15;

            //Act
            var soma = valorA + valorB;

            //Assert
            Assert.NotEqual(25, soma);
        }

        [Fact(DisplayName = "Teste Calulo Xunit")]
        [Trait("Exemplo Trait XUNit", "Calculo precisa ter uma Exception")]
        public void Calculo_Soma_Dois_Numeros_Exception()
        {
            Action somaAction = () =>
            {
                //Arrange
                int valorA = Convert.ToInt32("A");
                int valorB = 15;

                //Act
                var soma = valorA + valorB;
            };

            Func<object> somaFunc = () =>
            {
                //Arrange
                int valorA = Convert.ToInt32("A");
                int valorB = 15;

                //Act
                var soma = valorA + valorB;
                return soma;
            };

            //Assert
            Assert.Throws<FormatException>(somaAction);
            Assert.Throws<FormatException>(somaFunc);
        }
    }
}
