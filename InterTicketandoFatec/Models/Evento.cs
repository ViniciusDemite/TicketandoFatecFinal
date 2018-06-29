using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Evento
    {
        [Required]
        public int ID { get; set; } // <Chave primária> \\

        [Required]
        [MaxLength(200)]
        public string NomeEvento { get; set; }

        public decimal Valor { get; set; }
    }
}