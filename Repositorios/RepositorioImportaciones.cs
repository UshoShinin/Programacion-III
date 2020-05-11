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

        public IEnumerable<Importacion> FindAllSP()//Este es un FindAll pero sin cargar el producto, para la generación de archivos
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
                            Cod = (int)readerImportacion["Id"],
                            FechaIngreso = (DateTime)readerImportacion["FechaIngreso"],
                            FechaSalidaPrevista = (DateTime)readerImportacion["FechaSalida"],
                            Cantidad = (int)readerImportacion["Cantidad"],
                            Precio = (int)readerImportacion["Precio"],
                            Entregado = readerImportacion["Entregado"].ToString(),
                            Producto = new Producto
                            {
                                Cod = (int)readerImportacion["CodProd"],
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

        public IEnumerable<Importacion> FindAllClientsByRut(object Rut)
        {
            string RUT = (string)Rut;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT I.*,P.* FROM Importacion I JOIN Producto P on I.CodProd= P.Cod JOIN Cliente C ON P.RUT = C.RUT where C.RUT = @Rut AND I.Entregado='No'";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Rut", RUT);
                cn.Open();

                SqlDataReader readerImportacion = cmd.ExecuteReader();

                if (readerImportacion.HasRows)
                {
                    List<Importacion> Importaciones = new List<Importacion>();
                    while (readerImportacion.Read())
                    {
                        int Cod = (int)readerImportacion["Cod"];
                        string Nombre = readerImportacion["Nombre"].ToString();
                        int Peso = (int)readerImportacion["Peso"];
                        string Ruti = readerImportacion["RUT"].ToString();
                        Importaciones.Add(new Importacion
                        {
                            FechaIngreso = (DateTime)readerImportacion["FechaIngreso"],
                            FechaSalidaPrevista = (DateTime)readerImportacion["FechaSalida"],
                            Cantidad = (int)readerImportacion["Cantidad"],
                            Precio = (int)readerImportacion["Precio"],
                            Entregado = readerImportacion["Entregado"].ToString(),
                            Producto = new Producto
                            {
                                Cod = (int)readerImportacion["Cod"],
                                Nombre = readerImportacion["Nombre"].ToString(),
                                Peso = (int)readerImportacion["Peso"],
                                Rut = readerImportacion["RUT"].ToString()
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

        
        public IEnumerable<Gestion> FindAllGestion()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Gestion";
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader readerGestion = cmd.ExecuteReader();
                if (readerGestion.HasRows)
                {
                    List<Gestion> GestionList = new List<Gestion>();
                    while (readerGestion.Read())
                    {
                        GestionList.Add( new Gestion
                        {
                            Descuento = (int)readerGestion["descuento"],
                            Anios = (int)readerGestion["añosNecesarios"],
                            Comision =(int)readerGestion["comision"],
                            Fecha = (DateTime)readerGestion["fecha"]

                        });
                    }
                    cn.Close();
                    return GestionList;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Gestion GetGestionData()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Gestion WHERE Fecha=(SELECT MAX(Fecha) FROM Gestion)";
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader readerGestion = cmd.ExecuteReader();
                Gestion G = null;
                if (readerGestion.HasRows)
                {
                    if (readerGestion.Read())
                    {
                        G = new Gestion
                        {
                            Descuento = (int)readerGestion["descuento"],
                            Anios = (int)readerGestion["añosNecesarios"],
                            Comision = (int)readerGestion["comision"]
                        };
                    }
                    cn.Close();
                }
                return G;
            }
            catch
            {
                return null;
            }
        }




    }
}
