using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Agregados
using Dominio.EntidadesPortLog;
using Dominio.InterfacesRepositorios;
using Repositorios;

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
            Producto P = repoP.FindById(cod);
            return View(new Importacion {Producto=P});
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
        public ActionResult Create(Importacion importacion) {
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        if (importacion.Validar()) {
                            importacion.Producto = repoP.FindById(importacion.Cod);
                            if (repo.Add(importacion))
                                return RedirectToAction("Index");
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