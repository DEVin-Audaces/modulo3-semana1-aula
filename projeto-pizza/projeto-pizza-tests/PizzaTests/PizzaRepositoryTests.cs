using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;

namespace projeto_pizza_tests.PizzaTests
{
    public class PizzaRepositoryTests
    {
        [Theory]
        [InlineData("TESTE PIZZA MUSSARELA", 34)]
        [InlineData("TESTE PIZZA CATUPIRY", 66)]
        public void Salvar_Pizza_No_Repository_Sucesso(string descricaoPizza, decimal valorPizza)
        {
            //Arrange
            PizzaRepository pizzaRepository = new PizzaRepository(new TestPizzaDbContextFactory());
            PizzaModel pizzaModel = new PizzaModel() { Descricao = descricaoPizza, Valor = valorPizza };

            //Act
            int idInseridoDaPizza = pizzaRepository.Add(pizzaModel);

            //Assert
            Assert.NotEqual(0, idInseridoDaPizza);
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

        [Theory]
        [InlineData("TESTE PIZZA MUSSARELA", 34, 11)]
        [InlineData("TESTE PIZZA CATUPIRY", 66, 10)]
        public void Atualizar_Pizza_No_Repository_Com_Valor_Entre_Dez_A_Doze_Reias_Sucesso(string descricaoPizza, decimal valorPizzaInsert, decimal valorPizzaUpdate)
        {
            //Arrange
            PizzaRepository pizzaRepository = new PizzaRepository(new TestPizzaDbContextFactory());
            PizzaModel pizzaModel = new PizzaModel() { Descricao = descricaoPizza, Valor = valorPizzaInsert };

            //Act
            int idInseridoDaPizza = pizzaRepository.Add(pizzaModel);

            //Assert
            Assert.NotEqual(0, idInseridoDaPizza);

            //Arrange
            pizzaModel.Valor = valorPizzaUpdate;

            //Act
            pizzaRepository.Update(pizzaModel);
            var query = pizzaRepository.GetAll();
            decimal act = query.FirstOrDefault()!.Valor;

            //Assert
            Assert.InRange(act, 10, 12.99M);
        }

        [Theory]
        [InlineData("TESTE PIZZA MUSSARELA", 34, 11)]
        [InlineData("TESTE PIZZA CATUPIRY", 66, 10)]
        public void Atualizar_Pizza_No_Repository_Com_Valor_Entre_Dez_A_Doze_Reias_Com_Erro(string descricaoPizza, decimal valorPizzaInsert, decimal valorPizzaUpdate)
        {
            //Arrange
            PizzaRepository pizzaRepository = new PizzaRepository(new TestPizzaDbContextFactory());
            PizzaModel pizzaModel = new PizzaModel() { Descricao = descricaoPizza, Valor = valorPizzaInsert };

            //Act
            int idInseridoDaPizza = pizzaRepository.Add(pizzaModel);

            //Assert
            Assert.NotEqual(0, idInseridoDaPizza);

            //Arrange
            pizzaModel.Valor = valorPizzaUpdate;

            //Act
            pizzaRepository.Update(pizzaModel);
            var query = pizzaRepository.GetAll();
            decimal act = query.FirstOrDefault()!.Valor;

            //Assert
            Assert.NotInRange(act, 30, 50);
        }

    }
}