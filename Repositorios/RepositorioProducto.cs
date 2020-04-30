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
    public class RepositorioProducto : IRepositorio<Producto>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        public bool Add(Producto unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producto> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Producto";
                cmd.Connection = cn;
                cn.Open();

                SqlDataReader readerProducto = cmd.ExecuteReader();

                if (readerProducto.HasRows)
                {
                    List<Producto> Productos = new List<Producto>();
                    while (readerProducto.Read())
                    {
                        
                        Productos.Add(new Producto
                        {
                            Cod = (int)readerProducto["Cod"],
                            Nombre = readerProducto["Nombre"].ToString(),
                            Peso = (int)readerProducto["Peso"],
                            Rut = readerProducto["Rut"].ToString()
                        });
                    }
                    cn.Close();
                    return Productos;
                }
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public Producto FindById(object Id)
        {
            int Cod = (int)Id;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Producto WHERE Cod=@Cod";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Cod", Cod);
                cn.Open();
                SqlDataReader readerProducto = cmd.ExecuteReader();
                Producto ProductoEncontrado = null;
                if (readerProducto.HasRows)
                {
                    if (readerProducto.Read())
                    {
                        ProductoEncontrado = new Producto
                        {
                            Cod = (int)readerProducto["Cod"],
                            Nombre = readerProducto["Nombre"].ToString(),
                            Peso = (int)readerProducto["Peso"],
                            Rut = readerProducto["RUT"].ToString()
                        };
                    }
                    cn.Close();
                }
                return ProductoEncontrado;
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

        public bool Update(Producto unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
