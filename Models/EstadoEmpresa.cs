using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class EstadoEmpresa
    {
        public int EstadoId { get; set; }
        public int EmpresaId { get; set; }

        public virtual Empresa Empresa { get; set; }
        public virtual Estado Estado { get; set; }
    }
}
