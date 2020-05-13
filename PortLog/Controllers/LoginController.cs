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
            Session["rol"] = null;
            //TempData["Mesagge"] = null;
            ViewBag.Mesagge = TempData["Mesagge"];
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
                    
                        if (usu != null && usu.Password == usuario.Password && usu.Rol == usuario.Rol){
                        
                                if (usu.Rol == "admin") Session["rol"] = "Admin";
                                else Session["rol"] = "Deposito";
                                return RedirectToAction("Index", "Importacion");
                       
                        }else{
                            TempData["Mesagge"] = "Datos incorrectos";
                            return RedirectToAction("Index");
                        }
                    
                }
                else {
                    TempData["Mesagge"] = "Datos incorrectos";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                TempData["Mesagge"] = "Error";
                return RedirectToAction("Index");
            }
           
        }
    }
}