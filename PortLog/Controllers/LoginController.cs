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
    public class LoginController : Controller
    {
        private RepositorioUsuario repo = new RepositorioUsuario();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HolaMama() {
            return View();
        }
        [HttpPost]
        public ActionResult Logearse(Usuario usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usu = repo.FindById(usuario.CI);

                    if (usu != null && usu.Password == usuario.Password && usu.Rol == usuario.Rol)
                    {
                        ViewBag.Message = "Exito";
                        return RedirectToAction("HolaMama");
                    }
                    else
                    {
                        ViewBag.Message = "Datos incorrectos";
                        return RedirectToAction("Index");
                    }
                }
                else {
                    
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Message = "Error";
                return View();
            }
           
        }
    }
}