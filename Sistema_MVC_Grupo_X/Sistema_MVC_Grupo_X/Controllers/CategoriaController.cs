using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class CategoriaController : Controller
    {
        //instanciar la clase semestre
        private Categoria objCategoria = new Categoria();

        // GET: Semestre
        public ActionResult Index()
        {
            return View(objCategoria.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objCategoria.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Categoria() //Agrega un nuevo objeto
                : objCategoria.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Categoria objCategoria)
        {
            if (ModelState.IsValid)
            {
                objCategoria.Guardar();
                return Redirect("~/Categoria");
            }
            else
            {
                return View("~/Views/Categoria/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objCategoria.categoria_id = id;
            objCategoria.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}
