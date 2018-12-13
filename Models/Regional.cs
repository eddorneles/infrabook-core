using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Regional
    {
        public Regional()
        {
            Municipio = new HashSet<Municipio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }

        public virtual Estado Estado { get; set; }
        public virtual ICollection<Municipio> Municipio { get; set; }
    }
}
