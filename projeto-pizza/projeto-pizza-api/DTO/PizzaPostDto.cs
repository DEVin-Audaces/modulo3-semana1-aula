using System.ComponentModel.DataAnnotations;

namespace projeto_pizza_api.DTO
{
    public record PizzaPostDto([Required]string Descricao, [Required]decimal Valor)
    {
        public int? IdGerado { get; set; }
    }
}
