using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimiProImovel.Models
{

    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [StringLength(11)]
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
