using Newtonsoft.Json;
using projeto_pizza_api.DTO;
using System.Text;

namespace projeto_pizza_tests.PizzaTests
{
    public class PizzaIntegrationTests : ConfigurationHostApi
    {
        [Fact]
        public async Task Consumir_Api_Salvar_Pizza_Post_Sucesso()
        {
            //Arrange
            var body = new PizzaPostDto("Pizza Mussarela Integration", 89M);
            var jsonContent = JsonConvert.SerializeObject(body);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            //Act
            var returns = await client.PostAsync("/api/pizza", contentString);

            //Assert
            Assert.True(returns.IsSuccessStatusCode);

            jsonContent = await returns.Content.ReadAsStringAsync();
            var objetoResponse = JsonConvert.DeserializeObject<PizzaPostDto>(jsonContent);

            Assert.NotEqual(0, objetoResponse.IdGerado);
        }

    }
}
