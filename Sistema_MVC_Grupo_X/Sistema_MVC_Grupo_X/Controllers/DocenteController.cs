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
        public string Scripts()
        {
            String sqlCodigo = "";
            foreach (var obj in objDocente.Listar())
            {
                sqlCodigo = "Insert into Docente (docente_codigo, dni, apellido, nombre, sexo, email, celular, cargo, condicion, categoria, foto, estado) "
                    + "values (" + obj.docente_codigo + "," + obj.dni + "," + obj.apellido + "," + obj.nombre + "," + obj.sexo + "," + obj.email + "," + obj.celular + "," + obj.cargo + "," + obj.condicion + "," + obj.categoria + "," + obj.foto + "," + obj.estado + ")";
            }
            return HttpUtility.HtmlEncode(sqlCodigo);
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