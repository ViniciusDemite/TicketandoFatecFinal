using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InterTicketandoFatec.DAL
{
    public class Evento_UsuarioDAL : DAL
    {
        public List<CertificadoView> ReadCertificado()
        {
            List<CertificadoView> listaCertificado = new List<CertificadoView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from v_certificado";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                CertificadoView e = new CertificadoView();

                e.StatusId = (int)reader["statusId"];
                e.StatusParticipante = (string)reader["statusParticipante"];

                e.Chamadas.ID = (int)reader["id"];
                e.Chamadas.Nome = (string)reader["nome"];
                e.Chamadas.RG = (string)reader["rg"];
                e.Chamadas.RA = (string)reader["ra"];
                e.Chamadas.Curso = (string)reader["curso"];
                e.Chamadas.Email = (string)reader["email"];
                e.Chamadas.Login = (string)reader["login"];
                e.Chamadas.Senha = (string)reader["senha"];

                e.Chamadas.EventoId = (int)reader["eventoId"];
                e.Chamadas.Assunto = (string)reader["assunto"];
                e.Chamadas.CargaHoraria = (int)reader["cargaHoraria"];
                e.Chamadas.Conteudo = (string)reader["conteudo"];
                e.Chamadas.Data = (string)reader["data"];
                e.Chamadas.Descricao = (string)reader["descricao"];
                e.Chamadas.HoraInicio = (string)reader["horaInicio"];
                e.Chamadas.HoraFinal = (string)reader["horaFinal"];
                e.Chamadas.NomeConferente = (string)reader["nomeConferente"];
                e.Chamadas.Nome_Evento = (string)reader["nomeEvento"];
                e.Chamadas.TipoEvento = (string)reader["tipoEvento"];
                e.Chamadas.Valor = (decimal)reader["valor"];

                listaCertificado.Add(e);
            }
            return listaCertificado;
        }

        public List<ChamadaView> ReadEventosUsuario()
        {
            List<ChamadaView> lista = new List<ChamadaView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from v_nChamada";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ChamadaView cv = new ChamadaView();

                // <Usuarios> \\
                cv.ID = (int)reader["usuarioId"];
                cv.Nome = (string)reader["nomeUsuario"];
                cv.Email = (string)reader["email"];
                cv.Login = (string)reader["login"];
                cv.Curso = (string)reader["curso"];
                cv.RG = (string)reader["rg"];
                cv.RA = (string)reader["ra"];
                // </Usuarios> \\

                // <Atividades> \\
                cv.EventoId = (int)reader["eventoId"];
                cv.Nome_Evento = (string)reader["nome_evento"];
                cv.Descricao = (string)reader["descricao"];
                cv.NomeConferente = (string)reader["nomeConferente"];
                cv.Assunto = (string)reader["assunto"];
                cv.Conteudo = (string)reader["conteudo"];
                cv.TipoEvento = (string)reader["tipoEvento"];
                cv.Valor = (decimal)reader["valor"];
                cv.Data = (string)reader["data"];
                cv.HoraInicio = (string)reader["horaInicio"];
                cv.HoraFinal = (string)reader["horaFinal"];
                cv.CargaHoraria = (int)reader["cargaHoraria"];
                // </Atividades> \\

                lista.Add(cv);
            }
            return lista;
        }

        public void Create(Evento_Usuario eU)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Insert>
            ///
            /// INSERT INT eventos_usuarios VALUES (@evento_id, @usuario_id,
            /// @status_id, @certificado)
            /// 
            /// </Insert>
            cmd.CommandText = @"execute eventoUsuarioAdd @evento_id, @usuario_id, @status_id, @certificado";

            cmd.Parameters.AddWithValue("@evento_id", eU.Evento_id);
            cmd.Parameters.AddWithValue("@usuario_id", eU.Usuario_id);
            cmd.Parameters.AddWithValue("@status_id", eU.Status_id);
            cmd.Parameters.AddWithValue("@certificado", eU.Certificado);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id, int id2)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"delete from eventos_usuarios where
            usuario_id = @id and evento_id = @id2";

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@id2", id2);

            cmd.ExecuteNonQuery();
        }
    }
}