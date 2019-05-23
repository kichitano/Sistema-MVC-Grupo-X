using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
<<<<<<< HEAD
using Sistema_MVC_Grupo_X.Filters;
=======
>>>>>>> parent of 06eb0ea... Limpieza Master

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario objUsuario = new Usuario();
        private Docente objDocente = new Docente();
<<<<<<< HEAD
        [Autenticado]
=======
>>>>>>> parent of 06eb0ea... Limpieza Master
        //GET
        public ActionResult Index()
        {
            return View(objUsuario.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objUsuario.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Docente = objDocente.Listar();
            return View(
                id == 0 ? new Usuario() //Agrega un nuevo objeto
                : objUsuario.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Usuario objUsuario)
        {
            if (ModelState.IsValid)
            {
                objUsuario.Guardar();
                return Redirect("~/Usuario");
            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objUsuario.usuario_id = id;
            objUsuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}