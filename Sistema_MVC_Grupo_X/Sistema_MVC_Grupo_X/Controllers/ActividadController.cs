using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class ActividadController : Controller
    {
        private Actividad objActividad = new Actividad();
        private Semestre objSemestre = new Semestre();
        private Criterio objCriterio = new Criterio();
        private EvidenciaActividad objEvidenciaActividad = new EvidenciaActividad();

        // GET: Actividad
        public ActionResult Index()
        {
            return View(objActividad.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objActividad.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            ViewBag.Criterio = objCriterio.Listar();
            ViewBag.EvidenciaActividad = objEvidenciaActividad.Listar();
            return View(
                id == 0 ? new Actividad() //Agrega un nuevo objeto
                : objActividad.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Actividad objActividad)
        {
            if (ModelState.IsValid)
            {
                objActividad.Guardar();
                return Redirect("~/Actividad/AgregarEditar/" + objActividad.actividad_id);
            }
            else
            {
                return View("~/Views/Actividad/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objActividad.actividad_id = id;
            objActividad.Eliminar();
            return Redirect("~/Actividad");
        }
    }
}