using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class TipoDado
    {
        public TipoDado()
        {
            Atributo = new HashSet<Atributo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Atributo> Atributo { get; set; }
    }
}
