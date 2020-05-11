using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.InterfacesRepositorios;
using Dominio.EntidadesPortLog;
using System.Data;
using System.Data.SqlClient;


namespace Repositorios
{
    public class RepositorioUsuario : IRepositorio<Usuario>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;

        public bool Add(Usuario unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Usuario";
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader readerUsuario = cmd.ExecuteReader();
                if (readerUsuario.HasRows)
                {
                    List<Usuario> Usuarios = new List<Usuario>();
                    while (readerUsuario.Read())
                    {
                        Usuarios.Add(new Usuario
                        {
                            CI = (int)readerUsuario["CI"],
                            Password = readerUsuario["Pass"].ToString(),
                            Rol = readerUsuario["Rol"].ToString()

                        });
                    }
                    cn.Close();
                    return Usuarios;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Usuario FindById(object Id)
        {
            int CI = (int)Id;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Usuario WHERE CI=@CI";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@CI", CI);
                cn.Open();
                SqlDataReader readerUsuario = cmd.ExecuteReader();
                Usuario UsuarioLogeado = null;
                if (readerUsuario.HasRows)
                {
                    if (readerUsuario.Read())
                    {
                        UsuarioLogeado = new Usuario
                        {
                            CI = (int)readerUsuario["CI"],
                            Password = readerUsuario["Pass"].ToString(),
                            Rol = readerUsuario["Rol"].ToString()

                        };
                    }
                    cn.Close();
                }
                return UsuarioLogeado;
            }
            catch
            {
                return null;
            }
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Usuario unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
