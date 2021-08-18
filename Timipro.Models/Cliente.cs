using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Timipro.Models
{

    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(11)]
        [Index(IsUnique = true)]
        public string CPF { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(80)]
        public string Email { get; set; }

        public bool Ativo { get; set; }

    }


}
