using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Dominio.EntidadesPortLog;


namespace Dominio
{
    public static class ManejoDeArchivos
    {
        private static string ArchivoBaseImpo = AppDomain.CurrentDomain.BaseDirectory + "\\Importaciones.txt";
        private static string ArchivoBaseProd = AppDomain.CurrentDomain.BaseDirectory + "\\Productos.txt";
        private static string ArchivoBaseUsu = AppDomain.CurrentDomain.BaseDirectory + "\\Usuarios.txt";
        private static string ArchivoBaseCli = AppDomain.CurrentDomain.BaseDirectory + "\\Clientes.txt";
        private static string ArchivoBaseGest = AppDomain.CurrentDomain.BaseDirectory + "\\Gestiones.txt";
        //private static string ArchivoBase = "C:\\Usuario\\Usho\\BaseDeDatos.txt";
        public static void GuardarImportaciones(IEnumerable<Importacion> Importaciones,string delimitador)
        {
            try
            {
                foreach (Importacion Im in Importaciones)
                {
                    using (StreamWriter sw = new StreamWriter(ArchivoBaseImpo, true))
                    {
                        sw.WriteLine(
                            Im.Cod + delimitador+
                            Im.Producto.Cod + delimitador+
                            Im.FechaIngreso + delimitador +
                            Im.FechaSalidaPrevista + delimitador +
                            Im.Cantidad + delimitador+
                            Im.Precio + delimitador+
                            Im.Entregado
                            );
                    }
                }


            }
            catch (FileNotFoundException) { throw new FileNotFoundException("El archivo que se quiere utilizar no existe"); }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }

        }

        public static void GuardarProductos(IEnumerable<Producto> Productos, string delimitador)
        {
            try
            {
                foreach (Producto P in Productos)
                {
                    using (StreamWriter sw = new StreamWriter(ArchivoBaseProd, true))
                    {
                        sw.WriteLine(
                            P.Cod + delimitador +
                            P.Nombre + delimitador +
                            P.Peso + delimitador +
                            P.Rut
                            );
                    }
                }


            }
            catch (FileNotFoundException) { throw new FileNotFoundException("El archivo que se quiere utilizar no existe"); }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }

        }

        public static void GuardarClientes(IEnumerable<Cliente> Clientes, string delimitador)
        {
            try
            {
                foreach (Cliente C in Clientes)
                {
                    using (StreamWriter sw = new StreamWriter(ArchivoBaseCli, true))
                    {
                        sw.WriteLine(
                            C.Rut + delimitador +
                            C.Nombre + delimitador +
                            C.FechaIngreso
                            );
                    }
                }


            }
            catch (FileNotFoundException) { throw new FileNotFoundException("El archivo que se quiere utilizar no existe"); }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }

        }

        public static void GuardarUsuarios(IEnumerable<Usuario> Usuarios, string delimitador)
        {
            try
            {
                foreach (Usuario U in Usuarios)
                {
                    using (StreamWriter sw = new StreamWriter(ArchivoBaseUsu, true))
                    {
                        sw.WriteLine(
                            U.CI + delimitador +
                            U.Password + delimitador +
                            U.Rol
                            );
                    }
                }


            }
            catch (FileNotFoundException) { throw new FileNotFoundException("El archivo que se quiere utilizar no existe"); }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }

        }

        public static void GuardarGestiones(IEnumerable<Gestion> Gestiones, string delimitador)
        {

            try
            {
                foreach (Gestion G in Gestiones)
                {
                    using (StreamWriter sw = new StreamWriter(ArchivoBaseGest, true))
                    {
                        sw.WriteLine(
                            G.Descuento + delimitador +
                            G.Anios + delimitador +
                            G.Comision + delimitador +
                            G.Fecha
                            );
                    }
                }


            }
            catch (FileNotFoundException) { throw new FileNotFoundException("El archivo que se quiere utilizar no existe"); }
            catch (PathTooLongException) { throw; }
            catch (InvalidDataException) { throw; }
            catch (DirectoryNotFoundException) { throw; }
            catch (DriveNotFoundException) { throw; }
            catch (Exception) { throw; }

        }
    }
}
