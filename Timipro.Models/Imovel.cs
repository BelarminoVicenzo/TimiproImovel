using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timipro.Models
{

    public class Imovel
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(30)]
        public string Descricao { get; set; }

        [Required]
        public float Valor { get; set; }
        
        [Display(Name = "Estado")]
        public bool Ativo { get; set; }

        public int IdTipoNegocio { get; set; }
        
        
        public int IdCliente { get; set; }


        [ForeignKey(nameof(IdTipoNegocio))]
        public virtual TipoNegocio TipoNegocio { get; set; }
        
 
        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente Cliente { get; set; }
    }


}
