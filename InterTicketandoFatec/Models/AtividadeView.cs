using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class AtividadeView
    {
        // <Propriedade - Evento> \\
        [Required]
        [MaxLength(200)]
        public string Nome_Evento { get; set; }

        public decimal Valor { get; set; }
        // <Propriedade - Evento> \\

        // <Propriedade - Tipo> \\
        [MaxLength(200)]
        public string TipoEvento { get; set; } // <Nota: representa a descrição da entidade Tipo>
        // </Propriedade - Tipo> \\

        // <Propriedade - Conferente> \\
        [Required]
        [MaxLength(200)]
        public string NomeConferente { get; set; }

        [Required]
        [MaxLength(100)]
        public string Assunto { get; set; }

        [Required]
        [MaxLength(300)]
        public string Conteudo { get; set; }
        // <Propriedade - Conferente> \\

        // <Propriedade - Atividade> \\
        [Required]
        public int EventoId { get; set; } // <Nota: representa o ID de Atividade> \\

        [MaxLengthAttribute]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(20)]
        public string Data { get; set; }

        [Required]
        [MaxLength(5)]
        public string HoraInicio { get; set; }

        [Required]
        [MaxLength(5)]
        public string HoraFinal { get; set; }

        [Required]
        public int CargaHoraria { get; set; }
        // <Propriedade - Atividade> \\
    }
}