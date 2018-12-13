using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class Log
    {
        public int Id { get; set; }
        public string Acao { get; set; }
        public string Mensagem { get; set; }
        public string Usuario { get; set; }
    }
}
