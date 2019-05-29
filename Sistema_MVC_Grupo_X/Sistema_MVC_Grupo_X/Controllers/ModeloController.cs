using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class ModeloController : Controller
    {
        private Modelo objModelo = new Modelo();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objModelo.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objModelo.Obtener(id));
        } 

        //Action agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Modelo()  //Agrega un nuevo modelo
                : objModelo.Obtener(id) //Devuelve un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Modelo objModelo)
        {
            if (ModelState.IsValid)
            {
                objModelo.Guardar();
                return Redirect("~/Modelo");
            }
            else
            {
                return View("~/Views/Modelo/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objModelo.modelo_id = id;
            objModelo.Eliminar();
            return Redirect("~/Modelo");
        }
    }
}