using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Empresa
    {
        public Empresa()
        {
            EstadoEmpresa = new HashSet<EstadoEmpresa>();
            ItemConfiguracao = new HashSet<ItemConfiguracao>();
            Unidade = new HashSet<Unidade>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<EstadoEmpresa> EstadoEmpresa { get; set; }
        public virtual ICollection<ItemConfiguracao> ItemConfiguracao { get; set; }
        public virtual ICollection<Unidade> Unidade { get; set; }
    }
}
