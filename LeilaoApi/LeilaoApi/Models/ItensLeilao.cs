using System;
using System.Collections.Generic;

namespace LeilaoApi.Models
{
    public partial class ItensLeilao
    {
        public int Id { get; set; }
        public string NomeItem { get; set; }
        public decimal ValorInicial { get; set; }
        public bool FlagUsado { get; set; }
        public int Responsavel { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Usuarios ResponsavelNavigation { get; set; }
    }
}
