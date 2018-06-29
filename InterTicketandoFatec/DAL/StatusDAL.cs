using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace InterTicketandoFatec.DAL
{
    public class StatusDAL : DAL
    {
        public List<Status> ReadAll()
        {
            List<Status> lista = new List<Status>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from status"; // <Select pela view simples da tabela tipos> \\

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Status e = new Status();

                e.Descricao = (string)reader["descricao"];

                lista.Add(e);
            }
            return lista;
        }
    }
}