using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class EvidenciaCriterioController : Controller
    {
        //instanciar la clase semestre
        private EvidenciaCriterio objEvidenciaCriterio = new EvidenciaCriterio();
        // GET: Semestre
        public ActionResult Index()
        {
            return View(objEvidenciaCriterio.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEvidenciaCriterio.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new EvidenciaCriterio() //Agrega un nuevo objeto
                : objEvidenciaCriterio.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(EvidenciaCriterio objEvidenciaCriterio)
        {
            if (ModelState.IsValid)
            {
                objEvidenciaCriterio.Guardar();
                return Redirect("~/EvidenciaCriterio");
            }
            else
            {
                return View("~/Views/EvidenciaCriterio/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int ide, int idc)
        {
            objEvidenciaCriterio.evidencia_id = ide;
            objEvidenciaCriterio.criterio_id = idc;
            objEvidenciaCriterio.Eliminar();
            return Redirect("~/EvidenciaCriterio");
        }
    }
}