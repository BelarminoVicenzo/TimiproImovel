using System.ComponentModel.DataAnnotations;

namespace Timipro.Models
{
    public class TipoNegocio
    {

        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }


    }


}
