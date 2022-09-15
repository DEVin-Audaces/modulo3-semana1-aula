using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;

namespace projeto_pizza_tests.PizzaTests
{
    public class PizzaRepositoryTests
    {
        [Theory]
        [InlineData("TESTE PIZZA MUSSARELA", 34)]
        [InlineData("TESTE PIZZA CATUPIRY", 66)]
        public void Salvar_Pizza_No_Repository_Sucesso(string descricaoPizza, decimal valorPiza)
        {
            //Arrange
            PizzaRepository pizzaRepository = new PizzaRepository(new TestPizzaDbContextFactory());
            PizzaModel pizzaModel = new PizzaModel() { Descricao = descricaoPizza, Valor = valorPiza };

            //Act
            int idInseridoDaPizza = pizzaRepository.Add(pizzaModel);


            //Assert
            Assert.NotEqual(0, idInseridoDaPizza);

            //pizzaModel.Descricao = "TESTE PIZZA MUSSARELA ATUALIZADO";
            //pizzaRepository.Update(pizzaModel);


            //var query = pizzaRepository.GetAll();

        }

        [Fact]
        public void Salvar_Pizza_No_Repository_Com_Exception()
        {
            Action acaoSalvarComErro = () =>
            {
                //Arrange
                PizzaRepository pizzaRepository = new PizzaRepository(new TestPizzaDbContextFactory());
                PizzaModel pizzaModel = new PizzaModel();

                //Act
                int idInseridoDaPizza = pizzaRepository.Add(pizzaModel);
            };

            //Assert
            Assert.Throws<Exception>(acaoSalvarComErro);
        }
    }
}