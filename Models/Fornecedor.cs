using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Fornecedor
    {
        public Fornecedor()
        {
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
    }
}
