using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class TipoUnidade
    {
        public TipoUnidade()
        {
            Unidade = new HashSet<Unidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Unidade> Unidade { get; set; }
    }
}
