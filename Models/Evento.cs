using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataCompetencia { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal? Custo { get; set; }
        public int ItenConfiguracaoId { get; set; }
        public int TipoEventoId { get; set; }

        public virtual ItemConfiguracao ItenConfiguracao { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }
    }
}
