using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Tipo
    {
        public Tipo()
        {
            SubTipo = new HashSet<SubTipo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<SubTipo> SubTipo { get; set; }
    }
}
