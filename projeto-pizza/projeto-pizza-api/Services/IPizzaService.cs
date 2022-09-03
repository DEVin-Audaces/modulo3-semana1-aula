using projeto_pizza_api.DTO;

namespace projeto_pizza_api.Services
{
    public interface IPizzaService
    {
        int Add(PizzaPostDto pizzaPostDto);
        bool Update(PizzaPutDto pizzaPutDto);
        bool Delete(int id);
        IList<PizzaGetDto> GetAll();

        PizzaMaisCaraGetDto GetMaxValue();
        PizzaMaisBarataGetDto GetMinValue();
    }
}
