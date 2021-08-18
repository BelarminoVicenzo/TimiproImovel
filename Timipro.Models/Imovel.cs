using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timipro.Models
{

    public class Imovel
    {
        
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        public float Valor { get; set; }

        public bool Ativo { get; set; }

        public int IdTipoNegocio { get; set; }


        [ForeignKey(nameof(IdTipoNegocio))]
        public virtual TipoNegocio Genre { get; set; }
    }


}
