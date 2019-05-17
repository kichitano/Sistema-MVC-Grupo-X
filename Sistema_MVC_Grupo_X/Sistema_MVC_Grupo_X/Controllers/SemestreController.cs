using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class SemestreController : Controller
    {
        //instanciar la clase semestre
        private Semestre objSemestre = new Semestre();
        // GET: Semestre
        public ActionResult Index()
        {
            return View(objSemestre.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objSemestre.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Semestre() //Agrega un nuevo objeto
                : objSemestre.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Semestre objSemestre)
        {
            if (ModelState.IsValid)
            {
                objSemestre.Guardar();
                return Redirect("~/Semestre");
            }
            else
            {
                return View("~/Views/Semestre/AgregarEditar.cshtml");
            }
        }
        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objSemestre.semestre_id = id;
            objSemestre.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}