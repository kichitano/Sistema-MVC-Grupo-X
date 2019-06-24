using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class DocenteController : Controller
    {
        //instanciar la clase semestre
        private Docente objDocente = new Docente();
        // GET: Semestre
        public ActionResult Index()
        {
            return View(objDocente.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objDocente.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Docente() //Agrega un nuevo objeto
                : objDocente.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Docente objDocente)
        {
            if (ModelState.IsValid)
            {
                objDocente.Guardar();
                return Redirect("~/Docente");
            }
            else
            {
                return View("~/Views/Docente/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objDocente.docente_id = id;
            objDocente.Eliminar();
            return Redirect("~/Docente");
        }
    }
}