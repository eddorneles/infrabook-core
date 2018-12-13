using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Setor
    {
        public Setor()
        {
            UnidadeSetor = new HashSet<UnidadeSetor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<UnidadeSetor> UnidadeSetor { get; set; }
    }
}
