using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_pizza_api
{
    [Table("Pizza")]
    public class PizzaModel
    {
        [Key]
        [Column("Codigo")]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Descricao { get; set; }
        
        public decimal Valor { get; set; }
    }
}
