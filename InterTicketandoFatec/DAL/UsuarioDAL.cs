using InterTicketandoFatec.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;

namespace InterTicketandoFatec.DAL
{
    public class UsuarioDAL : DAL
    {
        // <Consulta geral> \\
        public List<Usuario> ReadAll()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Select>
            ///
            /// SELECT p.id as usuarioId, p.nome as nomeUsuario, u.email, u.login, u.curso,
            /// u.rg, u.ra
            /// FROM usuarios u, pessoas p
            /// WHERE p.id = u.pessoa_id
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_usuario";

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // <Duvida: não é necessário colocar a senha?> \\

                Usuario e = new Usuario();

                e.ID = (int)reader["usuarioId"];
                e.Nome = (string)reader["nomeUsuario"];
                e.Email = (string)reader["email"];
                e.Login = (string)reader["login"];
                e.Curso = (string)reader["curso"];
                e.RG = (string)reader["rg"];
                e.RA = (string)reader["ra"];

                listaUsuarios.Add(e);
            }
            return listaUsuarios;
        }

        public Usuario Read(int id)
        {
            Usuario e = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Select>
            ///
            /// SELECT p.id as usuarioId, p.nome as nomeUsuario, u.email, u.login, u.curso,
            /// u.rg, u.ra
            /// FROM usuarios u, pessoas p
            /// WHERE p.id = u.pessoa_id
            /// 
            /// </Select>
            cmd.CommandText = @"select * from v_usuario where usuarioId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                // <Duvida: não é necessário colocar a senha?> \\

                e = new Usuario();

                e.ID = (int)reader["usuarioId"];
                e.Nome = (string)reader["nomeUsuario"];
                e.Email = (string)reader["email"];
                e.Login = (string)reader["login"];
                e.Curso = (string)reader["curso"];
                e.RG = (string)reader["rg"];
                e.RA = (string)reader["ra"];
            }
            return e;
        }

        public Usuario RedUsuario(string login, string senha)
        {
            Usuario u = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"select * from v_usuario where login = @login AND senha = @senha";

            cmd.Parameters.AddWithValue("@login", login);
            cmd.Parameters.AddWithValue("@senha", senha);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                u = new Usuario();

                u.ID = (int)reader["usuarioId"];
                u.Nome = (string)reader["nomeUsuario"];
            }
            return u;
        }

        public void Create(Usuario usuarios)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Insert>
            ///
            /// INSERT INTO pessoas VALUES (@nome)
            /// INSERT INTO usuarios VALUES (@@IDENTITY, @rg, @ra, @curso, @email, @login,
            /// @senha)
            /// 
            /// </Insert>
            cmd.CommandText = @"execute cadUser @nome, @rg, @ra, @curso, @email, @login, @senha";

            cmd.Parameters.AddWithValue("@nome", usuarios.Nome);
            cmd.Parameters.AddWithValue("@rg", usuarios.RG);
            cmd.Parameters.AddWithValue("@ra", usuarios.RA);
            cmd.Parameters.AddWithValue("@curso", usuarios.Curso);
            cmd.Parameters.AddWithValue("@email", usuarios.Email);
            cmd.Parameters.AddWithValue("@login", usuarios.Login);
            cmd.Parameters.AddWithValue("@senha", usuarios.Senha);

            cmd.ExecuteNonQuery();
        }

        public void Update(Usuario usuarios)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            ///<Update>
            ///
            /// UPDATE pessoas SET nome = @nome WHERE id = @id
            /// UPDATE usuarios SET rg = @rg, ra = @ra, curso = @curso, email = @email,
            /// login = @login, senha = @senha WHERE pessoa_id = @id
            /// 
            /// </Update>
            cmd.CommandText = @"EXECUTE altUser @id, @nome, @rg, @ra, @curso, @email, @login, @senha";

            cmd.Parameters.AddWithValue("@id", usuarios.ID);
            cmd.Parameters.AddWithValue("@nome", usuarios.Nome);
            cmd.Parameters.AddWithValue("@rg", usuarios.RG);
            cmd.Parameters.AddWithValue("@ra", usuarios.RA);
            cmd.Parameters.AddWithValue("@curso", usuarios.Curso);
            cmd.Parameters.AddWithValue("@email", usuarios.Email);
            cmd.Parameters.AddWithValue("@login", usuarios.Login);
            cmd.Parameters.AddWithValue("@senha", usuarios.Senha);

            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = @"delete from v_usuario where usuarioId = @id";

            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();
        }
    }
}