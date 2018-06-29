using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using InterTicketandoFatec.Models;

namespace InterTicketandoFatec.DAL
{
    public class EventoDAL : DAL
    {
        // <Consulta geral dos conferentes> \\
        public List<Evento> ReadAll()
        {
            List<Evento> listaEventos = new List<Evento>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Select>
            /// 
            /// SELECT * 
            /// FROM eventos e
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_eventos";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Evento e = new Evento();

                e.ID = (int)reader["id"];
                e.NomeEvento = (string)reader["nome"];
                e.Valor = (decimal)reader["valor"];

                listaEventos.Add(e);
            }
            return listaEventos;
        }

        public Evento Read(int id)
        {
            Evento e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Select>
            /// 
            /// SELECT * 
            /// FROM eventos e
            /// 
            /// </Select>
            cmd.CommandText = @"select * from eventos where id = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                e = new Evento();

                e.NomeEvento = (string)reader["nome"];
            }
            return e;
        }

        public void Create(Evento eventos)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Insert>
            /// 
            /// INSERT INTO eventos VALUES (@nome, @valor)
            /// 
            /// </Insert>
            cmd.CommandText = @"execute eventoAdd @nome, @valor"; // <Nota: a procedure eventoAdd foi trocada para o inserte em sí. Com isso o sistema começou a cadastrar.> \\

            cmd.Parameters.AddWithValue("@nome", eventos.NomeEvento);
            cmd.Parameters.AddWithValue("@valor", eventos.Valor);

            cmd.ExecuteNonQuery();
        }

        public void Update(Evento eventos)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Update>
            ///
            /// UPDATE eventos SET nome    = @nome, valor   = @valor, WHERE id    = @id
            /// 
            /// </Update>
            cmd.CommandText = @"execute eventoAlt @id, @nome, @valor"; // <Nota: como o insert deu certo após tirar o procedure o mesmo foi feito aqui para futuro teste.> \\

            cmd.Parameters.AddWithValue("@id", eventos.ID);
            cmd.Parameters.AddWithValue("@nome", eventos.NomeEvento);
            cmd.Parameters.AddWithValue("@valor", eventos.Valor);

            cmd.ExecuteNonQuery();
        }

        //public void Delete(int id)
        //{
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Connection = connection;

        //    cmd.CommandText = @"delete from v_eventos where id = @id";

        //    cmd.Parameters.AddWithValue("@id", id);

        //    cmd.ExecuteNonQuery();
        //}
    }
}