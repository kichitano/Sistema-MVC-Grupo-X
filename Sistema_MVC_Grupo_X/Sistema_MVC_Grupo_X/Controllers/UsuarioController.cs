using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
using Sistema_MVC_Grupo_X.Filters;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class UsuarioController : Controller
    {
        private Usuario objUsuario = new Usuario();
        private Docente objDocente = new Docente();
        [Autenticado]
        //GET
        public ActionResult Index()
        {
            return View(objUsuario.Listar());
        }
        public string Scripts()
        {
            String sqlCodigo = "";
            foreach (var obj in objUsuario.Listar())
            {
                sqlCodigo = "Insert into Usuario (docente_id, nombre, clave, nivel, avatar, estado) "
                    + "values (" + obj.docente_id + "," + obj.nombre + "," + obj.clave + "," + obj.nivel + "," + obj.avatar + "," + obj.estado + ")";
            }
            return HttpUtility.HtmlEncode(sqlCodigo);
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