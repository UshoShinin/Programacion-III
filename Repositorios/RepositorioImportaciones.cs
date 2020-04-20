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
    public class RepositorioImportaciones : IRepositorio<Importacion>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        public bool Add(Importacion unObjeto)
        {
            if (unObjeto == null || !unObjeto.Validar()) return false;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Importacion VALUES(@Cod,@Nombre)";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Cod", unObjeto.Cod);
                cmd.Parameters.AddWithValue("@Nombre", unObjeto.Nombre);
                cn.Open();
                int filas = cmd.ExecuteNonQuery();
                cn.Close();
                return (filas == 1);
            }
            catch (Exception ex)
            {
                return false;
            }
                
            throw new NotImplementedException();
        }

        public IEnumerable<Importacion> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Importacion";
                cmd.Connection = cn;
                cn.Open();

                SqlDataReader readerImportacion = cmd.ExecuteReader();

                if (readerImportacion.HasRows)
                {
                    List<Importacion> Importaciones = new List<Importacion>();
                    while (readerImportacion.Read())
                    {
                        Importaciones.Add(new Importacion
                        {
                            Cod = (int)readerImportacion["Cod"],
                            Nombre = readerImportacion["Nombre"].ToString()
                        });
                    }
                    cn.Close();
                    return Importaciones;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Importacion FindById(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Importacion unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
