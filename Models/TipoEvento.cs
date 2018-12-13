using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class TipoEvento
    {
        public TipoEvento()
        {
            Evento = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
