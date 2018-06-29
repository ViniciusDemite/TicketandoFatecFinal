using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InterTicketandoFatec.DAL
{
    public class ComissaoDAL : DAL
    {
        // <Consulta geral - Comissao> \\
        public List<Comissao> Read()
        {

            List<Comissao> lista = new List<Comissao>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from comissoes where perfil <> 'administrador'";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Comissao comissoes = new Comissao();

                comissoes.ID = (int)reader["id"];
                comissoes.Login = (string)reader["login"];
                comissoes.Descricao = (string)reader["descricao"];
                comissoes.Evento_id = (int)reader["evento_id"];

                lista.Add(comissoes);
            }
            return lista;
        }

        public Comissao Read(int id)
        {

            Comissao c = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from comissoes where id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                c = new Comissao();

                c.ID = (int)reader["id"];
                c.Login = (string)reader["login"];
                c.Descricao = (string)reader["descricao"];
                c.Evento_id = (int)reader["evento_id"];
            }
            return c;
        }

        // <Consulta geral - Comissao Responsavel> \\
        public List<ComissaoResponsavelView> ReadResponsavel()
        {
            List<ComissaoResponsavelView> lista = new List<ComissaoResponsavelView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Select>
            ///
            /// SELECT c.id as comissaoId, c.login, c.descricao as descricaoComissao, c.perfil, e.*
            /// FROM comissoes c, v_nEvento e
            /// WHERE c.evento_id = e.evento_id
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_comissaoResponsavel";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                ComissaoResponsavelView c = new ComissaoResponsavelView();

                // <Comissao> \\
                c.ComissaoId = (int)reader["comissaoId"];
                c.Login = (string)reader["login"];
                c.DescricaoComissao = (string)reader["descricaoComissao"];
                c.Perfil = (string)reader["perfil"];
                // </Comissao> \\

                // <AtividadeView> \\
                c.Nome_Evento = (string)reader["nome_evento"];
                c.Valor = (decimal)reader["valor"];
                c.TipoEvento = (string)reader["tipoEvento"];
                c.NomeConferente = (string)reader["nomeConferente"];
                c.Assunto = (string)reader["assunto"];
                c.Conteudo = (string)reader["conteudo"];
                c.EventoId = (int)reader["eventoId"];
                c.Descricao = (string)reader["descricao"];
                c.Data = (string)reader["data"];
                c.HoraInicio = (string)reader["horaInicio"];
                c.HoraFinal = (string)reader["horaFinal"];
                c.CargaHoraria = (int)reader["cargaHoraria"];
                // </AtividadeView> \\

                lista.Add(c);
            }
            return lista;
        }

        public List<PessoaComissaoView> ReadPessoaComissao()
        {
            List<PessoaComissaoView> lista = new List<PessoaComissaoView>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Select>
            ///
            /// SELECT p.id as pessoaId, p.nome as nomeParticipanteComissao, c.id as comissaoId,
            /// c.login, c.descricao, c.perfil, e.nome as nomeEvento
            /// FROM pessoas_comissoes pc, pessoas p, comissoes c, eventos e
            /// WHERE pc.comissao_id = c.id AND pc.pessoa_id = p.id AND
            /// c.evento_id = e.id
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_pessoaComissao";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                PessoaComissaoView pc = new PessoaComissaoView();

                pc.PessoaId = (int)reader["pessoaId"];
                pc.NomeParticipanteComissao = (string)reader["nomeParticipanteComissao"];
                pc.ComissaoId = (int)reader["comissaoId"];
                pc.Login = (string)reader["login"];
                pc.Descricao = (string)reader["descricao"];
                pc.Perfil = (string)reader["perfil"];
                pc.NomeEvento = (string)reader["nomeEvento"];

                lista.Add(pc);
            }
            return lista;
        }

        // <Consulta para ver se há uma comissão com o login e senha utilizado> \\
        public Comissao Read(string login, string senha)
        {
            Comissao comissoes = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from comissoes where login = @login AND
            senha = @senha";

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                comissoes = new Comissao();

                comissoes.ID = (int)reader["id"];
                comissoes.Login = (string)reader["login"];
                comissoes.Descricao = (string)reader["descricao"];
                comissoes.Perfil = (string)reader["perfil"];
            }
            return comissoes;
        }

        public void Create(Comissao comissoes)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            
            ///<Insert>
            ///
            /// INSERT INTO comissoes VALUES (@senha, @login, @descricao, @perfil, @evento_id)
            /// 
            /// </Insert>
            cmd.CommandText = @"execute comissaoAdd @senha, @login, @descricao, @perfil, 
            @evento_id";

            cmd.Parameters.AddWithValue("@senha", comissoes.Senha);
            cmd.Parameters.AddWithValue("@login", comissoes.Login);
            cmd.Parameters.AddWithValue("@descricao", comissoes.Descricao);
            cmd.Parameters.AddWithValue("@perfil", comissoes.Perfil);
            cmd.Parameters.AddWithValue("@evento_id", comissoes.Evento_id);

            cmd.ExecuteNonQuery();
        }

        public void Update(Comissao comissoes)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Update>
            ///
            /// UPDATE comissoes SET senha = @senha, login = @login, descricao = @descricao
            /// perfil = @perfil, evento_id = @evento_id WHERE id = @id
            /// 
            /// </Update>
            cmd.CommandText = @"EXECUTE comissaoAlt @id, @senha, @login, @descricao, @perfil, @evento_id";

            cmd.Parameters.AddWithValue("@descricao", comissoes.Descricao);
            cmd.Parameters.AddWithValue("@login", comissoes.Login);
            cmd.Parameters.AddWithValue("@senha", comissoes.Senha);
            cmd.Parameters.AddWithValue("@perfil", comissoes.Perfil);
            cmd.Parameters.AddWithValue("@evento_id", comissoes.Evento_id);
            cmd.Parameters.AddWithValue("@id", comissoes.ID);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"delete from comissoes c 
                                inner join pessoas_comissoes pc on c.id = pc.comissoes_id
                                where pc.pessoa_id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}