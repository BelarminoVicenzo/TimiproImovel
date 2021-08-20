using System;
using System.Collections.Generic;
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
        [StringLength(40)]
        public string Nome { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(80)]
        public string Email { get; set; }
        [Display(Name ="Estado")]
        public bool Ativo { get; set; }

        public virtual ICollection<Imovel> Imovel { get; set; }

    }


}
