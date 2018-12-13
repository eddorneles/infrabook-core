using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Grupo
    {
        public Grupo()
        {
            InverseGrupoNavigation = new HashSet<Grupo>();
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? GrupoId { get; set; }

        public virtual Grupo GrupoNavigation { get; set; }
        public virtual ICollection<Grupo> InverseGrupoNavigation { get; set; }
        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
    }
}
