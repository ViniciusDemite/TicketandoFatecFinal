using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class Atividade
    {
        [Required]
        public int ID { get; set; } // <Chave primária> \\

        [Required]
        public int CargaHoraria { get; set; }

        [Required]
        [MaxLength(20)]
        public string Data { get; set; }

        [Required]
        [MaxLength(5)]
        public string HoraInicio { get; set; }

        [Required]
        [MaxLength(5)]
        public string HoraFinal { get; set; }

        [MaxLengthAttribute]
        public string DescricaoAtividade { get; set; }

        // <Chaves estrangeiras> \\
        [Required]
        public int Conferente_id { get; set; }

        [Required]
        public int Tipo_id { get; set; }

        [Required]
        public int Evento_id { get; set; }
        // </Chaves entrangeiras> \\
    }
}