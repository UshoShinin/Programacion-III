using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//Agregados
using Dominio;
using Dominio.EntidadesPortLog;
using Dominio.InterfacesRepositorios;
using Repositorios;
using PortLog.RefServPortLog;

namespace PortLog.Controllers
{
    public class GeneradorController : Controller
    {
        private RepositorioImportaciones repo = new RepositorioImportaciones();
        private RepositorioProducto repoP = new RepositorioProducto();
        private RepositorioCliente repoC = new RepositorioCliente();
        private RepositorioUsuario repoU = new RepositorioUsuario();

        // GET: Generador
        public ActionResult Index()
        {

            ManejoDeArchivos.GuardarImportaciones(repo.FindAllSP(),";");
            ManejoDeArchivos.GuardarProductos(repoP.FindAll(), ";");
            ManejoDeArchivos.GuardarClientes(repoC.FindAll(), ";");
            ManejoDeArchivos.GuardarUsuarios(repoU.FindAll(), ";");
            ManejoDeArchivos.GuardarGestiones(repo.FindAllGestion(), ";");

            return View();
        }
    }
}