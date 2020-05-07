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
            if (unObjeto == null)  return false;

            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Importacion VALUES(@Cod,@fechaI,@fechaS,@Cantidad,@Precio,@Entregado)";
                cmd.Parameters.AddWithValue("@Cod", unObjeto.Producto.Cod);
                SqlParameter parameter1 = new SqlParameter();
                parameter1.ParameterName = "@fechaI";
                parameter1.SqlDbType = SqlDbType.DateTime2;
                parameter1.Value = unObjeto.FechaIngreso;
                cmd.Parameters.Add(parameter1);

                SqlParameter parameter2 = new SqlParameter();
                parameter2.ParameterName = "@fechaS";
                parameter2.SqlDbType = SqlDbType.DateTime2;
                parameter2.Value = unObjeto.FechaSalidaPrevista;
                cmd.Parameters.Add(parameter2);

                cmd.Parameters.AddWithValue("@Cantidad", unObjeto.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", unObjeto.Precio);
                cmd.Parameters.AddWithValue("@Entregado", unObjeto.Entregado);
                cmd.Connection = cn;
                
                
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
                cmd.CommandText = "SELECT * FROM Importacion I JOIN Producto P on I.CodProd= P.Cod";
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

                            FechaIngreso = (DateTime)readerImportacion["FechaIngreso"],
                            FechaSalidaPrevista = (DateTime)readerImportacion["FechaSalida"],
                            Cantidad = (int)readerImportacion["Cantidad"],
                            Precio = (int)readerImportacion["Precio"],
                            Entregado = readerImportacion["Entregado"].ToString(),
                            Producto = new Producto {
                                Cod = (int)readerImportacion["Cod"],
                                Nombre = readerImportacion["Nombre"].ToString(),
                                Peso = (int)readerImportacion["Peso"],
                                Rut = readerImportacion["RUT"].ToString(),
                            }
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
