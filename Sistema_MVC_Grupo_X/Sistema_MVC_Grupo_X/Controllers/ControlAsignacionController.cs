using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class ControlAsignacionController : Controller
    {
        private ControlAsignacion objControlAsignacion = new ControlAsignacion();
        //GET
        public ActionResult Index()
        {
            return View(objControlAsignacion.Listar());
        }

        //Action Visualizar
        public ActionResult Consultar(int id)
        {
            ViewBag.consulta = objControlAsignacion.Obtener(id);
            return View(ViewBag.consulta);
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new ControlAsignacion() //Agrega un nuevo objeto
                : objControlAsignacion.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(int controlAsignacion_id, int control_id, 
            int docente_id, int criterio_id, DateTime fechaAsignacion, DateTime fechaCulminacion,
            string duracion, string sustento, string porcentaje, string condicion, 
            string archivo, string observacion, string estado)
        {
            objControlAsignacion.controlasignacion_id = controlAsignacion_id;
            objControlAsignacion.control_id = control_id;
            objControlAsignacion.docente_id = docente_id;
            objControlAsignacion.criterio_id = criterio_id;
            objControlAsignacion.fechaasignacion = fechaAsignacion;
            objControlAsignacion.fechaculminacion = fechaCulminacion;
            objControlAsignacion.duracion = duracion;
            objControlAsignacion.sustento = sustento;
            objControlAsignacion.porcentaje = porcentaje;
            objControlAsignacion.condicion = condicion;
            objControlAsignacion.archivo = archivo;
            objControlAsignacion.observacion = observacion;
            objControlAsignacion.estado = estado;

            if (ModelState.IsValid)
            {
                objControlAsignacion.Guardar();
                return Redirect("~/Control/AgregarEditar/" + control_id);
            }
            else
            {
                return View("~/Views/Control/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id, int control_id)
        {
            objControlAsignacion.controlasignacion_id = id;
            objControlAsignacion.Eliminar();
            return Redirect("~/Control/AgregarEditar/" + control_id);
        }
    }
}