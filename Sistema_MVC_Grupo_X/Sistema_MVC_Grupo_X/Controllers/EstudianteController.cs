using Sistema_MVC_Grupo_X.Filters;
using Sistema_MVC_Grupo_X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class EstudianteController : Controller
    {
        private Estudiante objEstudiante = new Estudiante();
        [Autenticado]
        // GET: Estudiante
        public ActionResult Index()
        {
            return View(objEstudiante.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEstudiante.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Estudiante() //Agrega un nuevo objeto
                : objEstudiante.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Estudiante objEstudiante)
        {
            if (ModelState.IsValid)
            {
                objEstudiante.Guardar();
                return Redirect("~/Estudiante");
            }
            else
            {
                return View("~/Views/Estudiante/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objEstudiante.estudiante_id = id;
            objEstudiante.Eliminar();
            return Redirect("~/Estudiante");
        }
    }
}