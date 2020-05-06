using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Agregados
using Dominio.EntidadesPortLog;
using Dominio.InterfacesRepositorios;
using Repositorios;
using PortLog.RefServPortLog;

namespace PortLog.Controllers
{
    public class ImportacionController : Controller
    {
        private RepositorioImportaciones repo = new RepositorioImportaciones();
        private RepositorioProducto repoP = new RepositorioProducto();
        // GET: Importacion
        public ActionResult Index()
        {
            IEnumerable<Importacion> importaciones = repo.FindAll();
            if (importaciones == null || importaciones.Count() == 0)
            {
                ViewBag.Mensaje = "No hay importaciones registrados";
                importaciones = new List<Importacion>(); // Esto es para evitar que el modelo llegue en null a la vista
            }
            else
                ViewBag.Mensaje = "Operación exitosa";
            return View(importaciones);
        }
        [HttpPost]

        public ActionResult Index(Importacion unaImportacion)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repo.Add(unaImportacion))
                        return RedirectToAction("Index");
                }
                return View(unaImportacion);
            }
            catch { return View(); }
        }
        public ActionResult Create(string Id)
        {
            if (Id == null) return View();
            int cod;
            Int32.TryParse(Id,out cod);//No se logra parsear el resultado del selec a int para utilizar el FindById
            ServicioPortLogClient US = new ServicioPortLogClient();
            US.Open();
            DtoProducto P = US.ProductoXId(cod);
            US.Close();
            return View(new DtoImportacion {Producto=P});
        }
        public ActionResult SelectProd() {
            IEnumerable<Producto> productos = repoP.FindAll();
            if (productos == null || productos.Count() == 0)
            {
                ViewBag.Mensaje = "No hay clientes registrados";
            }
            else
                ViewBag.Mensaje = "Operación exitosa";
            return View(productos);
        }
        [HttpPost]
        public ActionResult Create(DtoImportacion importacion) {
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        ServicioPortLogClient unServicio = new ServicioPortLogClient();
                        unServicio.Open();
                        importacion.Producto = unServicio.ProductoXId(importacion.Cod);
                        importacion.Entregado = "No";
                        if (unServicio.AgregarImportacion(importacion))
                        {
                            unServicio.Close();
                            return RedirectToAction("SelectProd");
                        }
                    }
                    return View(importacion);
                }
                catch
                {
                    return View();
                }
            }
        }

    }

}