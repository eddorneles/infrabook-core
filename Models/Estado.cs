using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Estado
    {
        public Estado()
        {
            EstadoEmpresa = new HashSet<EstadoEmpresa>();
            Regional = new HashSet<Regional>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Uf { get; set; }

        public virtual ICollection<EstadoEmpresa> EstadoEmpresa { get; set; }
        public virtual ICollection<Regional> Regional { get; set; }
    }
}
