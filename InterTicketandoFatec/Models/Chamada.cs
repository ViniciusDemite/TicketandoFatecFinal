using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Chamada
    {
        // <Chaves estrangeiras primárias> \\
        [Required]
        public int Usuario_id { get; set; }

        [Required]
        public int Atividade_id { get; set; }
    }
}