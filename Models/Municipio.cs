using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Municipio
    {
        public Municipio()
        {
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
            Unidade = new HashSet<Unidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int RegionalId { get; set; }

        public virtual Regional Regional { get; set; }
        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
        public virtual ICollection<Unidade> Unidade { get; set; }
    }
}
