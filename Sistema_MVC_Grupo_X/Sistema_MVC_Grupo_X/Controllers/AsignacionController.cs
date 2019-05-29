using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class AsignacionController : Controller
    {
        private Asignacion objAsignacion = new Asignacion();
        private Semestre objSemestre = new Semestre();
        private Docente objDocente = new Docente();
        //GET
        public ActionResult Index()
        {
            return View(objAsignacion.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objAsignacion.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            ViewBag.Docente = objDocente.Listar();
            return View(
                id == 0 ? new Asignacion() //Agrega un nuevo objeto
                : objAsignacion.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Asignacion objAsignacion)
        {
            if (ModelState.IsValid)
            {
                objAsignacion.Guardar();
                return Redirect("~/Asignacion/AgregarEditar/"+objAsignacion.asignacion_id);
            }
            else
            {
                return View("~/Views/Asignacion/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objAsignacion.asignacion_id = id;
            objAsignacion.Eliminar();
            return Redirect("~/Asignacion");
        }
    }
}