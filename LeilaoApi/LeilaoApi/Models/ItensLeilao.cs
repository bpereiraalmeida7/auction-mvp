using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LeilaoApi.Models
{
    public partial class ItensLeilao
    {
        public int Id { get; set; }

        [Required]
        public string NomeItem { get; set; }

        [Required]
        public decimal ValorInicial { get; set; }
        public bool FlagUsado { get; set; }

        [Required]
        public int Responsavel { get; set; }

        [Required]
        public DateTime DataAbertura { get; set; }

        [Required]
        public DateTime DataFinalizacao { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Usuarios ResponsavelNavigation { get; set; }
    }
}
