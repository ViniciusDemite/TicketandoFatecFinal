using System.ComponentModel.DataAnnotations;

namespace InterTicketandoFatec.Models
{
    public class PessoaComissaoView
    {
        // <Propriedade - Pessoa> \\
        [Required]
        public int PessoaId { get; set; } // <Chave estrangeira> \\

        [Required]
        [MaxLength(200)]
        public string NomeParticipanteComissao { get; set; } // <Pessoa - Nome> \\
        // </Propriedade - Pessoa> \\

        // <Propriedade - Comissao> \\
        [Required]
        public int ComissaoId { get; set; } // <Chave estrangeira> \\
        // </Propriedade - Comissao> \\

        // <Propriedade - Evento> \\
        [Required]
        [MaxLength(200)]
        public string NomeEvento { get; set; }
        // </Propriedade - Evento> \\

        // <Propriedade - Comissao> \\
        [Required]
        [MaxLength(100)]
        public string Login { get; set; }

        [MaxLengthAttribute]
        public string Descricao { get; set; }

        [Required]
        [MaxLength(20)]
        public string Perfil { get; set; }
        // </Propriedade - Comissao> \\
    }
}