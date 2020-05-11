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
        public ActionResult Index()
        {
            if (Session["rol"] == "Admin") return View();
            else if(Session["rol"] == "Deposito") return RedirectToAction("Index", "Importacion");
            else return RedirectToAction("Index", "Login");
        }

        
        // GET: Usuario/Create

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