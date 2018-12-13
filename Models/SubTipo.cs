using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class SubTipo
    {
        public SubTipo()
        {
            InverseSubTipoNavigation = new HashSet<SubTipo>();
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int TipoId { get; set; }
        public int? SubTipoId { get; set; }

        public virtual SubTipo SubTipoNavigation { get; set; }
        public virtual Tipo Tipo { get; set; }
        public virtual ICollection<SubTipo> InverseSubTipoNavigation { get; set; }
        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
    }
}
