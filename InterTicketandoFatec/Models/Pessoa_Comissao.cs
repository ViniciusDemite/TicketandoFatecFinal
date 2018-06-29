using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Pessoa_Comissao
    {
        [Required]
        public int Pessa_Id { get; set; }

        [Required]
        public int Comissao_Id { get; set; }
    }
}