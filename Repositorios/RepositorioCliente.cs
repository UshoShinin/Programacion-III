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
    public class RepositorioCliente : IRepositorio<Cliente>
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["miConexion"].ConnectionString;
        public bool Add(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> FindAll()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Cliente";
                cmd.Connection = cn;
                cn.Open();
                SqlDataReader readerCliente = cmd.ExecuteReader();
                if (readerCliente.HasRows)
                {
                    List<Cliente> Clientes = new List<Cliente>();
                    while (readerCliente.Read())
                    {
                        Clientes.Add( new Cliente
                        {
                            Rut = readerCliente["RUT"].ToString(),
                            Nombre = readerCliente["Nombre"].ToString(),
                            FechaIngreso = (DateTime)readerCliente["FechaIngreso"]
                        });
                    }
                    cn.Close();
                    return Clientes;
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        public Cliente FindById(object Rut)
        {
            string RUT = (string)Rut;
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select * FROM Cliente WHERE RUT=@Rut";
                cmd.Connection = cn;
                cmd.Parameters.AddWithValue("@Rut", RUT);
                cn.Open();
                SqlDataReader readerCliente = cmd.ExecuteReader();
                Cliente Cli = null;
                if (readerCliente.HasRows)
                {
                    if (readerCliente.Read())
                    {
                        Cli =new Cliente
                        {
                            Rut = readerCliente["RUT"].ToString(),
                            Nombre = readerCliente["Nombre"].ToString(),
                            FechaIngreso = (DateTime)readerCliente["FechaIngreso"]
                        };
                    }
                    cn.Close();
                }
                return Cli;
            }
            catch
            {
                return null;
            }
        }

        public IEnumerable<Cliente> FindAllWithImport()
        {
            SqlConnection cn = new SqlConnection(cadenaConexion);
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT C.* FROM Importacion I JOIN Producto P on I.CodProd= P.Cod JOIN Cliente C ON P.RUT = C.RUT group by C.RUT,C.Nombre,C.FechaIngreso";
                cmd.Connection = cn;
                cn.Open();

                SqlDataReader readerCliente = cmd.ExecuteReader();

                if (readerCliente.HasRows)
                {
                    List<Cliente> Clientes = new List<Cliente>();
                    while (readerCliente.Read())
                    {
                        Clientes.Add(new Cliente
                        {
                            Rut = readerCliente["RUT"].ToString(),
                            Nombre = readerCliente["Nombre"].ToString(),
                            FechaIngreso = (DateTime)readerCliente["FechaIngreso"]
                        });
                    }
                    cn.Close();
                    return Clientes;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public bool Remove(object Id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Cliente unObjeto)
        {
            throw new NotImplementedException();
        }
    }
}
