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
    }
}