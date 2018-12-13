using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Atributo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public int ItemConfiguracaoId { get; set; }
        public int TipoDadoId { get; set; }
        public int? UnidadeMedidaId { get; set; }

        public virtual ItemConfiguracao ItemConfiguracao { get; set; }
        public virtual TipoDado TipoDado { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
    }
}
