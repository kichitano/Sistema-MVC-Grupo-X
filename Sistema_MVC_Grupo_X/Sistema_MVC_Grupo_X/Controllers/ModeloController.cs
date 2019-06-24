using Sistema_MVC_Grupo_X.Filters;
using Sistema_MVC_Grupo_X.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
using Sistema_MVC_Grupo_X.Filters;

namespace Sistema_MVC_Grupo_X.Controllers
{
    [Autenticado]
    public class ModeloController : Controller
    {
        private Modelo objModelo = new Modelo();
        private Criterio objCriterio = new Criterio();
        // GET: Modelo
        public ActionResult Index()
        {
            return View(objModelo.Listar());
        }

        public ActionResult GraficoBarras()
        {
            ViewBag.Criterio = objCriterio.Listar();
            return View(objModelo.ObtenerCantidadCriterios());
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
