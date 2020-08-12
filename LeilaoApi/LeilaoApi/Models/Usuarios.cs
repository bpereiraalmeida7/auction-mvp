using System;
using System.Collections.Generic;

namespace LeilaoApi.Models
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            ItensLeilao = new HashSet<ItensLeilao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public bool Situacao { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<ItensLeilao> ItensLeilao { get; set; }
    }
}
