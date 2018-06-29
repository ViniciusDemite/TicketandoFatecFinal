using InterTicketandoFatec.Models;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace InterTicketandoFatec.DAL
{
    public class ConferenteDAL : DAL
    {
        // <Consulta geral dos conferentes> \\
        public List<Conferente> ReadAll()
        {
            List<Conferente> listaConferentes = new List<Conferente>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Select>
            /// 
            /// SELECT c.pessoa_id as conferenteId, p.nome as nomeConferente, c.assunto, c.conteudo
            /// FROM conferentes c, pessoas p
            /// WHERE c.pessoa_id = p.id
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_conferente"; // <Nota: v_conferente é uma view Join que já monstra os dados de pessoa.> \\

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Conferente e = new Conferente();

                e.ID = (int)reader["conferenteId"];
                e.Nome = (string)reader["nomeConferente"];
                e.Assunto = (string)reader["assunto"];
                e.Conteudo = (string)reader["conteudo"];

                listaConferentes.Add(e);
            }
            return listaConferentes;
        }

        public void Create(Conferente conferentes)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Insert>
            /// 
            /// INSERT INTO pessoas VALUES (@nome)
            /// INSERT INTO conferentes VALUES (@@IDENTITY, @assunto, @conteudo)
            /// 
            /// </Insert>
            cmd.CommandText = @"execute cadConf @nome, @assunto, @conteudo";

            cmd.Parameters.AddWithValue("@nome", conferentes.Nome);
            cmd.Parameters.AddWithValue("@assunto", conferentes.Assunto);
            cmd.Parameters.AddWithValue("@conteudo", conferentes.Conteudo);

            cmd.ExecuteNonQuery();
        }

        public void Update(Conferente conferentes)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Update>
            /// 
            /// UPDATE pessoa SET @nome WHERE id = @id
            /// UPDATE conferentes SET nome = @nome, assunto = @assunto, conteudo = @conteudo, WHERE pessoa_id = @id
            /// 
            /// </Update>
            cmd.CommandText = @"execute altConf @id, @nome, @assunto, @conteudo";

            // <Duvida: mesmo sendo um caso de herança ainda há a necessidade de colocar o parametro para o id?> \\ 

            cmd.Parameters.AddWithValue("@id", conferentes.ID);
            cmd.Parameters.AddWithValue("@nome", conferentes.Nome);
            cmd.Parameters.AddWithValue("@assunto", conferentes.Assunto);
            cmd.Parameters.AddWithValue("@conteudo", conferentes.Conteudo);

            cmd.ExecuteNonQuery();
        }

        //public void Delete(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = connection;

        //    cmd.CommandText = @"dele from v_conferente where conferente_id = @id";

        //    cmd.Parameters.AddWithValue("@id", id);

        //    cmd.ExecuteNonQuery();
        //}
    }
}