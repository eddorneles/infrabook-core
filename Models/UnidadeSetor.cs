using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class UnidadeSetor
    {
        public UnidadeSetor()
        {
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
        }

        public int UnidadeSetor1 { get; set; }
        public int UnidadeId { get; set; }
        public int SetorId { get; set; }

        public virtual Setor Setor { get; set; }
        public virtual Unidade Unidade { get; set; }
        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
    }
}
