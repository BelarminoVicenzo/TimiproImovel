using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timipro.Models
{
    public class ClienteImovel
    {
        
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdImovel { get; set; }



        [ForeignKey(nameof(IdCliente))]
        public virtual Cliente User { get; set; }

        [ForeignKey(nameof(IdImovel))]
        public virtual Imovel Quadrinho { get; set; }
    }


}
