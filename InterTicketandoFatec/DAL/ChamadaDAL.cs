using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InterTicketandoFatec.DAL
{
    public class ChamadaDAL : DAL
    {
        public List<ChamadaView> ReadAll(int id)
        {
            List<ChamadaView> lista = new List<ChamadaView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from v_nChamada where usuarioId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                ChamadaView c = new ChamadaView();

                // <Usuario> \\
                c.ID = (int)reader["usuarioId"];
                c.Login = (string)reader["login"];
                c.RG = (string)reader["rg"];
                c.RA = (string)reader["ra"];
                c.Email = (string)reader["email"];
                c.Curso = (string)reader["curso"];
                // </Usuario> \\

                // <Atividade> \\
                c.NomeConferente = (string.IsNullOrEmpty(c.NomeConferente) ? "null" : c.NomeConferente);
                c.Nome_Evento = (string)reader["nome_evento"];
                c.Data = (string)reader["data"];
                c.Conteudo = (string)reader["conteudo"];
                c.Assunto = (string)reader["assunto"];
                c.CargaHoraria = (int)reader["cargaHoraria"];
                c.Descricao = (string.IsNullOrEmpty(c.Descricao) ? "null" : c.Descricao);
                c.TipoEvento = (string)reader["tipoEvento"];
                c.Valor = (decimal)reader["valor"];
                c.HoraInicio = (string)reader["horaInicio"];
                c.HoraFinal = (string)reader["horaFinal"];
                // </Atividade> \\

                lista.Add(c);
            }
            return lista;
        }

        public void Insercrever(int idUsuario, int idAtividade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"execute chamadaAdd @usuario_id, @atividade_id";

            cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
            cmd.Parameters.AddWithValue("@atividade_id", idAtividade);

            cmd.ExecuteNonQuery();
        }

        public void Deinscrever(int idUsuario, int idAtividade)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"delete from chamadas where usuario_id = @usuario_id and atividade_id = @atividade_id";

            cmd.Parameters.AddWithValue("@usuario_id", idUsuario);
            cmd.Parameters.AddWithValue("@atividade_id", idAtividade);

            cmd.ExecuteNonQuery();
        }
    }
}