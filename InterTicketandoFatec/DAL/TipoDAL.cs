using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InterTicketandoFatec.DAL
{
    public class TipoDAL : DAL
    {
        public List<Tipo> Read()
        {
            List<Tipo> lista_Tipos = new List<Tipo>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            /// <Select>
            /// 
            /// SELECT *
            /// FROM tipos t
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_tipos"; // <Select pela view simples da tabela tipos> \\

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Tipo e = new Tipo();

                e.ID = (int)reader["id"];
                e.DescricaoTipo = (string)reader["descricao"];

                lista_Tipos.Add(e);
            }
            return lista_Tipos;
        }
    }
}