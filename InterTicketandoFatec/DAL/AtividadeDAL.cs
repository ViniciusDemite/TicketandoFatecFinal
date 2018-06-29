using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace InterTicketandoFatec.DAL
{
    public class AtividadeDAL : DAL
    {
        // <Consulta geral das atividades> \\
        public List<AtividadeView> ReadAll()
        {
            List<AtividadeView> listaAtividades = new List<AtividadeView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Select>
            /// 
            /// SELECT a.id as eventoId, e.nome as nome_evento, a.descricao, c.nomeConferente, c.assunto,
            /// c.conteudo, t.descricao as tipoEvento, e.valor, a.data, a.horaInicio, a.horaFinal, a.cargaHoraria
            /// FROM atividades a, v_conferente c, eventos e, tipos t
            /// WHERE a.id = e.id AND a.id = t.id AND a.id = c.ConferenteID
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_nEvento";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                AtividadeView a = new AtividadeView();

                // <Evento> \\
                a.Nome_Evento = (string)reader["nome_evento"];
                a.Valor = (decimal)reader["valor"];
                // </Evento> \\

                // <Tipo> \\
                a.TipoEvento = (string)reader["tipoEvento"];
                // </Tipo> \\

                // <Conferente> \\
                a.NomeConferente = (string)reader["nomeConferente"];
                a.Assunto = (string)reader["assunto"];
                a.Conteudo = (string)reader["conteudo"];
                // </Conferente> \\

                // <Atividade> \\
                a.EventoId = (int)reader["eventoId"];
                a.Descricao = (string.IsNullOrEmpty(a.Descricao) ? "null" : a.Descricao);
                a.Data = (string)reader["data"];
                a.HoraInicio = (string)reader["horaInicio"];
                a.HoraFinal = (string)reader["horaFinal"];
                a.CargaHoraria = (int)reader["cargaHoraria"];
                // </Atividade> \\

                listaAtividades.Add(a);
            }
            return listaAtividades;
        }

        public void Create(Atividade atividades)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Insert>
            ///
            /// INSERT INTO atividades VALUES (@cargaHoraria, @data, @horaInicio, @horaFinal, @descricao,
            /// @conferente_id, @tipo_id, @evento_id)
            /// 
            ///</Insert>
            cmd.CommandText = @"execute atividadeAdd @cargaHoraria, @data, @horaInicio,
            @horaFinal, @descricao, @conferente_id, @tipo_id, @evento_id";

            cmd.Parameters.AddWithValue("@cargaHoraria", atividades.CargaHoraria);
            cmd.Parameters.AddWithValue("@data", atividades.Data);
            cmd.Parameters.AddWithValue("@horaInicio", atividades.HoraInicio);
            cmd.Parameters.AddWithValue("@horaFinal", atividades.HoraFinal);
            cmd.Parameters.AddWithValue("@descricao", atividades.DescricaoAtividade);

            // <Chaves estrangeiras> \\
            cmd.Parameters.AddWithValue("@conferente_id", atividades.Conferente_id);
            cmd.Parameters.AddWithValue("@tipo_id", atividades.Tipo_id);
            cmd.Parameters.AddWithValue("@evento_id", atividades.Evento_id);
            // </Chaves estrangeiras> \\

            cmd.ExecuteNonQuery();
        }

        public void Update(Atividade atividades)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Update>
            ///
            /// UPDATE atividades SET cargaHoraria = @cargaHoraria, data = @data, horaInicio = @horaInicio, horaFinal = @horaFinal,
            /// descricao = @descricao, conferente_id = @conferente_id, tipo_id = @tipo_id, evento_id = @evento_id
            /// WHERE id = @id
            /// 
            ///</Update>
            cmd.CommandText = @"execute atividadeAlt @cargaHoraria, @data, @horaInicio,
            @horaFinal, @descricao, @conferente_id, @tipo_id, @evento_id";

            cmd.Parameters.AddWithValue("@eventoId", atividades.ID);
            cmd.Parameters.AddWithValue("@cargaHoraria", atividades.CargaHoraria);
            cmd.Parameters.AddWithValue("@data", atividades.Data);
            cmd.Parameters.AddWithValue("@horaInicio", atividades.HoraInicio);
            cmd.Parameters.AddWithValue("@horaFinal", atividades.HoraFinal);
            cmd.Parameters.AddWithValue("@descricao", atividades.DescricaoAtividade);

            //<Chaves estrangeiras>
            cmd.Parameters.AddWithValue("@conferente_id", atividades.Conferente_id);
            cmd.Parameters.AddWithValue("@tipo_id", atividades.Tipo_id);
            cmd.Parameters.AddWithValue("@evento_id", atividades.Evento_id);
            //</Chaves estrangeiras>

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"delete from v_nEventos where eventoId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}