using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class ControlController : Controller
    {
        private Control objControl = new Control();
        private Semestre objSemestre = new Semestre();
        //GET
        public ActionResult Index()
        {
            return View(objControl.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objControl.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            return View(
                id == 0 ? new Control() //Agrega un nuevo objeto
                : objControl.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Control objControl)
        {
            if (ModelState.IsValid)
            {
                objControl.Guardar();
                return Redirect("~/Control");
            }
            else
            {
                return View("~/Views/Control/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objControl.control_id = id;
            objControl.Eliminar();
            return Redirect("~/Control");
        }
    }
}