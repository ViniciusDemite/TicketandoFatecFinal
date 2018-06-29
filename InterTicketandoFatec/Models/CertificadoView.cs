namespace InterTicketandoFatec.Models
{
    public class CertificadoView
    {
        // <Propriedade - ChamadaView> \\
        public ChamadaView Chamadas { get; set; }
        // </Propriedade - ChamadaView> \\

        // <Propriedade - Status> \\
        public int StatusId { get; set; }

        public string StatusParticipante { get; set; }
        // </Propriedade - Status> \\
    }
}