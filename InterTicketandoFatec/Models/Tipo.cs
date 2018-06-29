using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Tipo
    {
        [Required]
        public int ID { get; set; } // <Chave primária> \\

        [MaxLength(200)]
        public string DescricaoTipo { get; set; }
    }
}