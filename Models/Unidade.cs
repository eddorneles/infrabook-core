using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Unidade
    {
        public Unidade()
        {
            UnidadeSetor = new HashSet<UnidadeSetor>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int MunicipioId { get; set; }
        public int TipoUnidadeId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Municipio Municipio { get; set; }
        public virtual TipoUnidade TipoUnidade { get; set; }
        public virtual ICollection<UnidadeSetor> UnidadeSetor { get; set; }
    }
}
