using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class ItemConfiguracao
    {
        public ItemConfiguracao()
        {
            Atributo = new HashSet<Atributo>();
            Evento = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? FornecedorId { get; set; }
        public int GrupoId { get; set; }
        public int MunicipioId { get; set; }
        public int? UnidadeSetorId { get; set; }
        public int SubTipoId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual SubTipo SubTipo { get; set; }
        public virtual UnidadeSetor UnidadeSetor { get; set; }
        public virtual ICollection<Atributo> Atributo { get; set; }
        public virtual ICollection<Evento> Evento { get; set; }
    }
}
