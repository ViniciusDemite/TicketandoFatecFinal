using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Conferente : Pessoa
    {
        [Required]
        [MaxLength(100)]
        public string Assunto { get; set; }

        [Required]
        [MaxLength(300)]
        public string Conteudo { get; set; }
    }
}