using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Status
    {
        [Required]
        public int ID { get; set; }

        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}