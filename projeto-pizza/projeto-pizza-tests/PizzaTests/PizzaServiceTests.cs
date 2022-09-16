using Moq;
using projeto_pizza_api.DTO;
using projeto_pizza_api.Models;
using projeto_pizza_api.Repositories;
using projeto_pizza_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto_pizza_tests.PizzaTests
{
    public class PizzaServiceTests
    {
        [Theory(Skip = "Rotina com erro no mock")]
        [InlineData("TESTE PIZZA MUSSARELA", 34)]
        [InlineData("TESTE PIZZA CATUPIRY", 66)]
        public void Salvar_Pizza_Com_Caracteres_Acima_Cinco_Descricao_Sucesso(string descricaoPizza, decimal valorPizza)
        {
            //Arrange
            Mock<IPizzaRepository<PizzaModel>> mockPizzaRepository = new Mock<IPizzaRepository<PizzaModel>>();
            mockPizzaRepository.Setup(s => s.Add(It.IsAny<PizzaModel>())).Returns(int.MaxValue);

            //Act
            var pizzaService = new PizzaService(mockPizzaRepository.Object);
            var act = pizzaService.Add(new PizzaPostDto(descricaoPizza, valorPizza));

            //Assert
            Assert.InRange(act, 98764, 98765);
        }


        [Theory]
        [InlineData(34)]
        [InlineData(66)]
        public void Deletar_Pizza_Com_Sucesso(int id)
        {
            //Arrange
            Mock<IPizzaRepository<PizzaModel>> mockPizzaRepository = new Mock<IPizzaRepository<PizzaModel>>();
            mockPizzaRepository.Setup(s => s.Delete(It.IsAny<int>())).Returns(true);

            //Act
            var pizzaService = new PizzaService(mockPizzaRepository.Object);
            var act = pizzaService.Delete(id);

            //Assert
            Assert.True(act);
        }

        [Fact]
        public void Buscar_GetMaxValue_Sucesso()
        {
            //Arrange
            Mock<IPizzaRepository<PizzaModel>> mockPizzaRepository = new Mock<IPizzaRepository<PizzaModel>>();

            var listaRepoReturns = new List<PizzaModel>
            {
                new PizzaModel { Id = 1, Descricao = "teste 1", Valor = 45 },
                new PizzaModel { Id = 2, Descricao = "teste 2", Valor = 12 },
                new PizzaModel { Id = 3, Descricao = "teste 3", Valor = 78 },
                new PizzaModel { Id = 4, Descricao = "teste 4", Valor = 33 },
                new PizzaModel { Id = 65, Descricao = "teste 65", Valor = 1 },
                new PizzaModel { Id = 777, Descricao = "teste 777", Valor = 876 },
                new PizzaModel { Id = 2345, Descricao = "teste 2345", Valor = 6577 },
                new PizzaModel { Id = 5, Descricao = "teste 5", Valor = 33 },
                new PizzaModel { Id = 8, Descricao = "teste 8", Valor = 55 },
                new PizzaModel { Id = 9, Descricao = "teste 9", Valor = 1 },
                new PizzaModel { Id = 11, Descricao = "teste 11", Valor = 65 },
            };

            mockPizzaRepository.Setup(s => s.GetAll()).Returns(listaRepoReturns);

            //Act
            var pizzaService = new PizzaService(mockPizzaRepository.Object);
            var act = pizzaService.GetMaxValue();

            //Assert
            Assert.Equal(3, act.Id);
            Assert.Equal(78, act.Valor);
        }


    }
}
