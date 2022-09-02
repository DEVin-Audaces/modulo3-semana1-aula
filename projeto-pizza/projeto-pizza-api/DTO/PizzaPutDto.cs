using System.ComponentModel.DataAnnotations;

namespace projeto_pizza_api.DTO
{
    public class PizzaPutDto
    {
        [Required]
        public int Id { get; init; }
        
        [Required]
        [MaxLength(20)]
        public string Descricao { get; init; } = "";

        [Required]
        public decimal Valor { get; init; }
    }
}
