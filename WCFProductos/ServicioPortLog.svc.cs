using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Dominio.EntidadesPortLog;
using Repositorios;


namespace WCFProductos
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServicioPortLog : IServicioPortLog
    {
        public bool AgregarImportacion(DtoImportacion DtoImp)
        {
            if (DtoImp == null) return false;
            RepositorioImportaciones repoImport = new RepositorioImportaciones();
            return repoImport.Add(new Importacion
            {
                Cod = DtoImp.Cod,
                FechaIngreso = DtoImp.FechaIngreso,
                FechaSalidaPrevista = DtoImp.FechaSalidaPrevista,
                Producto = PasarDtoAProducto(DtoImp.Producto),
                Cantidad = DtoImp.Cantidad,
                Precio = DtoImp.precio,
                Entregado = DtoImp.Entregado
            });

        }

        public DtoProducto ProductoXId(int id)
        {
            RepositorioProducto repoPro = new RepositorioProducto();
            Producto unPro = repoPro.FindById(id);
            if (unPro == null) return null;
            DtoProducto dto = new DtoProducto
            {
                cod = unPro.Cod,
                Nombre = unPro.Nombre,
                Peso = unPro.Peso,
                Rut = unPro.Rut
            };
            return dto;
        }

        public Producto PasarDtoAProducto(DtoProducto p) {
            return new Producto {
                Cod = p.cod,
                Nombre = p.Nombre,
                Peso = p.Peso,
                Rut = p.Rut,
            };
        }

        public DtoProducto PasarProductoADto(Producto p)
        {
            return new DtoProducto
            {
                cod = p.Cod,
                Nombre = p.Nombre,
                Peso = p.Peso,
                Rut = p.Rut,
            };
        }

        public IEnumerable<DtoProducto> MostrarProductos() {
            RepositorioImportaciones repo = new RepositorioImportaciones();
            IEnumerable<Importacion> Importaciones = repo.FindAll();
            List<DtoProducto> PreProductos = new List<DtoProducto>();
            List<DtoProducto> Productos = new List<DtoProducto>();

            foreach (Importacion I in Importaciones) {
                if (I.Entregado == "No")
                {
                    PreProductos.Add(new DtoProducto
                    {
                        cod = I.Producto.Cod,
                        Nombre = I.Producto.Nombre,
                        Peso = I.Producto.Peso,
                        Rut = I.Producto.Rut,
                        Stock = I.Cantidad

                    });
                }
            }

            foreach (DtoProducto P in PreProductos) {
                int index = Found(P, Productos);
                if (index != -1)
                {
                    Productos[index].Stock += P.Stock;
                }
                else {
                    Productos.Add(P);
                }
            }
            return Productos;
        }

        public int Found(DtoProducto P,List<DtoProducto> Productos) {
            for(int i = 0;i<Productos.Count;i++){
                if (P.cod == Productos[i].cod) return i;
            }
            return -1;
        }

    }
}
