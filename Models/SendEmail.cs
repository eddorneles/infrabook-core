using System;
using System.Collections.Generic;

namespace InfraBook.Models
{
    public partial class SendEmail
    {
        public int Id { get; set; }
        public string Remetente { get; set; }
        public string Destinatario { get; set; }
        public string Subject { get; set; }
        public string Mensagem { get; set; }
    }
}
