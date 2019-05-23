using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class ModeloController : Controller
    {
        private Modelo objModelo = new Modelo();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objModelo.Listar());
        }
        //Ación Visualizar
        public ActionResult Visualizar(int id)
        {

            return View(objModelo.obtener(id));
        }

        // Accion AgregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(id == 0 ? new Modelo() // Agrega un nuevo objeto
                : objModelo.obtener(id)); // Devuelve un objeto
        }

        //Acion Guardar
        public ActionResult Guardar(Modelo objModelo)
        {
            if (ModelState.IsValid)
            {
                objModelo.Guardar();
                return Redirect("~/Modelo");
            }
            else
            {
                return View("~/Views/Modelo/AgregarEditar.cshtml");
            }
        }

        //Action Eliminar
        public ActionResult Eliminar(int id)
        {
            objModelo.modelo_id = id;
            objModelo.Eliminar();
            return Redirect("~/Modelo");
        }
    }
}