using projeto_pizza_api.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace projeto_pizza_api.Models
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


        //public static implicit operator PizzaGetDto(PizzaModel model)
        //{
        //    return new PizzaGetDto
        //    {
        //        Id = model.Id,
        //        Descricao = model.Descricao,
        //        Valor = model.Valor
        //    };
        //}

        public static explicit operator PizzaGetDto(PizzaModel model)
        {
            return new PizzaGetDto
            {
                Id = model.Id,
                Descricao = model.Descricao
            };
        }
    }
}
