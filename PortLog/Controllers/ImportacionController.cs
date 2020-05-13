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
        private RepositorioCliente repoC = new RepositorioCliente();

        // GET: Importacion
        public ActionResult Index()
        {
            if (Session["rol"] != null) {

                ServicioPortLogClient US = new ServicioPortLogClient();
                US.Open();
                IEnumerable<DtoProducto> Prdos = US.MostrarProductos();
                US.Close();
                return View(Prdos);
            } 
            else return RedirectToAction("Index", "Login");
            
        }
        public ActionResult Create(string Id)
        {
            if (Id == null) return RedirectToAction("SelectProd");
            int cod;
            Int32.TryParse(Id,out cod);//No se logra parsear el resultado del selec a int para utilizar el FindById
            ServicioPortLogClient US = new ServicioPortLogClient();
            US.Open();
            DtoProducto P = US.ProductoXId(cod);
            US.Close();
            return View(new DtoImportacion {Producto=P});
        }
        public ActionResult SelectProd() {
            if (Session["rol"] == "Deposito")
            {
                IEnumerable<Producto> productos = repoP.FindAll();
                ViewBag.Mesagge = TempData["Mesagge"];
                return View(productos);
            }
            else if (Session["rol"] == "Admin") return RedirectToAction("Index", "Importacion");
            else return RedirectToAction("Index","Login");
            
        }
        public ActionResult SelectClient()
        {
            if (Session["rol"] == "Admin")
            {
                IEnumerable<Cliente> Clientes = repoC.FindAllWithImport();
                if (Clientes == null || Clientes.Count() == 0)
                {
                    ViewBag.Mensaje = "No hay clientes registrados";
                }
                else
                    ViewBag.Mensaje = "Operación exitosa";
                return View(Clientes);
                }
            else if (Session["rol"] == "Deposito") return RedirectToAction("Index", "Importacion");
            else return RedirectToAction("Index", "Login");
        }
        public ActionResult Show(string Rut) {
            if (Rut == null) return RedirectToAction("SelectClient");
            IEnumerable<Importacion> ImportacionesPendientes = repo.FindAllClientsByRut(Rut);
            Cliente Cli = repoC.FindById(Rut);
            Gestion G = repo.GetGestionData();
            bool Des = (DateTime.Now.Year - Cli.FechaIngreso.Year)>=G.Anios;
            double days;
            double Total = 0;
            foreach (Importacion Im in ImportacionesPendientes) {
                if (Im.FechaSalidaPrevista < DateTime.Now) days = (DateTime.Now- Im.FechaIngreso).TotalDays;
                else days = (Im.FechaSalidaPrevista- Im.FechaIngreso).TotalDays;
                Total += days * Im.Precio;
            }
            if (Des) {
                Total -= Total / 100 * G.Descuento;
                    }
            Total = Total/100*G.Comision;
            ViewBag.Total = Total;
           

return View(Cli);
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
                        if ((Convert.ToDateTime("01/01/0001") != importacion.FechaIngreso && Convert.ToDateTime("01/01/0001") != importacion.FechaSalidaPrevista) && importacion.FechaIngreso <= importacion.FechaSalidaPrevista)
                        {
                            if (unServicio.AgregarImportacion(importacion))
                            {
                                unServicio.Close();
                                return RedirectToAction("Index");
                            }
                        }
                        else {
                            TempData["Mesagge"] = "Alguna de las fechas es inválida";
                            return RedirectToAction("SelectProd");
                        }

                        
                    }
                    return RedirectToAction("SelectProd");
                }
                catch
                {
                    return RedirectToAction("SelectProd");
                }
            }
        }

    }

}