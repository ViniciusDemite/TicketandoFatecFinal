namespace InterTicketandoFatec.Models
{
    public class ChamadaView
    {
        // <Propriedade - Usuario> \\
        public int ID { get; set; }

        public string Nome { get; set; }

        public string RG { get; set; }

        public string RA { get; set; }

        public string Curso { get; set; }

        public string Email { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
        // </Propriedade - Usuario> \\

        // <Propriedade - AtividadeView> \\
        public string Nome_Evento { get; set; }

        public decimal Valor { get; set; }

        public string TipoEvento { get; set; }

        public string NomeConferente { get; set; }

        public string Assunto { get; set; }

        public string Conteudo { get; set; }

        public int EventoId { get; set; }

        public string Descricao { get; set; }

        public string Data { get; set; }

        public string HoraInicio { get; set; }

        public string HoraFinal { get; set; }

        public int CargaHoraria { get; set; }
        // </Propriedade - Atividade View> \\
    }
}