using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Evento_Usuario
    {
        // <Chaves estrangeiras primárias> \\
        [Required]
        public int Evento_id { get; set; }

        [Required]
        public int Usuario_id { get; set; }

        [Required]
        public int Status_id { get; set; }
        // </Chaves estrangeiras primárias> \\

        [MaxLength(3)]
        public string Certificado { get; set; }
    }
}