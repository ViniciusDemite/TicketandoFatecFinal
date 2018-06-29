using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Comissao
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [MaxLength(20)]
        public string Senha { get; set; }

        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [MaxLengthAttribute]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(20)]
        public string Perfil { get; set; }

        [Required]
        public int Evento_id { get; set; } // <Chave estrangeira> \\
    }
}