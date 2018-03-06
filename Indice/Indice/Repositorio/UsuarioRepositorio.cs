using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Indice.Models;
using System.Data;

namespace Indice.Repositorio
{
    public class UsuarioRepositorio
    {
        private SqlConnection conn;

        private void Connetion()
        {
            string constr = ConfigurationManager.ConnectionStrings["stringConexao"].ToString();
            conn = new SqlConnection(constr);
        }



        // Adicionar Usuario
        public bool AdicionarUsuario(Usuarios  usuarioObj)
        {
            Connetion();

            int i;

            using (SqlCommand command = new SqlCommand("IncluirTime", conn))

            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Nome", usuarioObj.Nome);
                command.Parameters.AddWithValue("@Telefone", usuarioObj.Telefone);
                command.Parameters.AddWithValue("@Email", usuarioObj.Email);

                conn.Open();

                i = command.ExecuteNonQuery();

            }

            conn.Close();


            return i >= 1;

      
        }

        // Obter todos os Usuarios
        public List<Usuarios> ObterUsuarios()
        {
            Connetion();
            List<Usuarios> usuariosList = new List<Usuarios>();

            using (SqlCommand command = new SqlCommand("ObterUsuarios", conn))
            {
                command.CommandType = CommandType.StoredProcedure;

                conn.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Usuarios usuario = new Usuarios()
                    {
                        UsuariosId = Convert.ToInt32(reader["Usuarioid"]),
                        Nome = Convert.ToString(reader["Nome"]),
                        Telefone = Convert.ToString(reader["Telefone"]),
                        Email = Convert.ToString(reader["Email"]),

                    };

                    usuariosList.Add(usuario);
                }

                conn.Close();

                return usuariosList;

            }
        
        }


        //Atualizar Usuario
        public bool AtualizarUsuario(Usuarios usuarioObj)
        {
            Connetion();

            int i;

            using (SqlCommand command = new SqlCommand("AtualizarUsuario", conn))

            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioID", usuarioObj.UsuariosId);
                command.Parameters.AddWithValue("@Nome", usuarioObj.Nome);
                command.Parameters.AddWithValue("@Telefone", usuarioObj.Telefone);
                command.Parameters.AddWithValue("@Email", usuarioObj.Email);

                conn.Open();

                i = command.ExecuteNonQuery();

            }

            conn.Close();


            return i >= 1;


        }

        //Excluir Usuario
        public bool ExluirUsuario(int id)
        {
            Connetion();

            int i;

            using (SqlCommand command = new SqlCommand("ExluirUsuarioPorID", conn))

            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UsuarioID", id);
               

                conn.Open();

                i = command.ExecuteNonQuery();

            }

            conn.Close();

            if (i >= 1)
            {
                return true;
            }

            return false;
           


        }

    }
}