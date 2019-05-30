using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class DetalleAsignacionController : Controller
    {
        private DetalleAsignacion objDetalleAsignacion = new DetalleAsignacion();
        private Asignacion objAsignacion = new Asignacion();
        private Docente objDocente = new Docente();
        private Criterio objCriterio = new Criterio();
        //GET
        public ActionResult Index()
        {
            return View(objDetalleAsignacion.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objDetalleAsignacion.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Asignacion = objAsignacion.Listar();
            ViewBag.Docente = objDocente.Listar();
            ViewBag.Criterio = objCriterio.Listar();
            return View(
                id == 0 ? new DetalleAsignacion() //Agrega un nuevo objeto
                : objDetalleAsignacion.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(int detalleAsignacion_id, int asignacion_id, int docente_id, int criterio_id, string estado)
        {
            objDetalleAsignacion.detalleasignacion_id = detalleAsignacion_id;
            objDetalleAsignacion.asignacion_id = asignacion_id;
            objDetalleAsignacion.docente_id = docente_id;
            objDetalleAsignacion.criterio_id = criterio_id;
            objDetalleAsignacion.estado = estado;

            if (ModelState.IsValid)
            {
                objDetalleAsignacion.Guardar();
                return Redirect("~/Asignacion/AgregarEditar/" + asignacion_id);
            }
            else
            {
                return View("~/Views/Control/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id,int asignacion_id)
        {
            objDetalleAsignacion.detalleasignacion_id = id;
            objDetalleAsignacion.Eliminar();
            return Redirect("~/Asignacion/AgregarEditar/" + asignacion_id);
        }
    }
}