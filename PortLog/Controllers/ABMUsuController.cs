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
    public class ABMUsuController : Controller
    {

        private RepositorioUsuario repoU = new RepositorioUsuario();

        // GET: Admin
        public ActionResult Index(int? CI)
        {
            if (Session["Admin"] != null)
                return RedirectToAction("Create", "ABMUsu");
            return View();

           /* if (CI != null)
            {
                Empleado e = SoftwORT.Instancia.ObtenerEmpXId(id.Value);
                ViewBag.EmpleadoAModificar = e;
            }
            return View(SoftwORT.Instancia.ListaEmpleados);*/
        }

        
        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario unUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (repoU.Add(unUsuario))
                        return RedirectToAction("Index");
                }

                return View(unUsuario);
            }
            catch
            {
                return View();
            }
        }

        // GET: Clientes/Edit/?idCliente=5
    }
}