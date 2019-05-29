using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class CriterioController : Controller
    {
        private Criterio objCriterio = new Criterio();
        private Modelo objModelo = new Modelo();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objCriterio.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objCriterio.Obtener(id));
        }

        //Action agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Modelo = objModelo.Listar();
            return View(
                id == 0 ? new Criterio()  //Agrega un nuevo modelo
                : objCriterio.Obtener(id) //Devuelve un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Criterio objCriterio)
        {
            if (ModelState.IsValid)
            {
                objCriterio.Guardar();
                return Redirect("~/Criterio");
            }
            else
            {
                return View("~/Views/Criterio/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objCriterio.modelo_id = id;
            objCriterio.Eliminar();
            return Redirect("~/Criterio");
        }
    }
}