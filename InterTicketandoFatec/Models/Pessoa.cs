using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Pessoa
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
    }
}