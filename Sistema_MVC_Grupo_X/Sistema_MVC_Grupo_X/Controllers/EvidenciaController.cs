using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class EvidenciaController : Controller
    {
        //instanciar la clase semestre
        private Evidencia objEvidencia = new Evidencia();
        private Semestre objSemestre = new Semestre();
        private Categoria objCategoria = new Categoria();
        private Criterio objCriterio = new Criterio();
        private Modelo objModelo = new Modelo();
        private EvidenciaCriterio objEvidenciaCriterio = new EvidenciaCriterio();

        // GET: Semestre
        public ActionResult Index()
        {
            ViewBag.Criterio = objCriterio.Listar();
            ViewBag.EvidenciaCriterio = objEvidenciaCriterio.Listar();
            ViewBag.Semestre = objSemestre.Listar();
            ViewBag.Categoria = objCategoria.Listar();
            ViewBag.Modelo = objModelo.Listar();

            return View(objEvidencia.Listar());
        }

        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEvidencia.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Semestre = objSemestre.Listar();
            ViewBag.Categoria = objCategoria.Listar();
            ViewBag.EvidenciaCriterio = objEvidenciaCriterio.Listar();
            ViewBag.Modelo = objModelo.Listar();
            if(id > 0)
            {
                ViewBag.EvidenciaCriterioAct = objEvidenciaCriterio.ListarPorEvidencia(id);
            }

            return View(
                id == 0 ? new Evidencia() //Agrega un nuevo objeto
                : objEvidencia.Obtener(id) //Devuelva un objeto
                );
        }
        //Accion guardar
        [HttpPost]
        public ActionResult Guardar(HttpPostedFileBase cargar_Archivo, Evidencia objEvidencia, int idModelo = 0, int[] criterios = null, string archivo_actual = "")
        {
            var ecAct = TempData["ecAct"];
            if (ecAct != null)                
            {
                ViewBag.EvidenciaCriterioAct = ecAct;
                List<EvidenciaCriterio> objEvidenciasCriteriosAct = ViewBag.EvidenciaCriterioAct;                
                foreach (var ec in objEvidenciasCriteriosAct)
                {
                    objEvidenciaCriterio.Eliminar2(ec.evidencia_id , ec.criterio_id);
                }
            }

            
            if (ModelState.IsValid)
            {
                objEvidencia.Guardar();
                if (!(archivo_actual.Equals(objEvidencia.archivo_evidencia)))
                {
                    subirArchivo(cargar_Archivo, objEvidencia.evidencia_id.ToString());
                }
                for (int i = 0; i < criterios.Count(); i++)
                {
                    objEvidenciaCriterio = new EvidenciaCriterio();
                    objEvidenciaCriterio.evidencia_id = objEvidencia.evidencia_id;
                    objEvidenciaCriterio.criterio_id = criterios[i];
                    objEvidenciaCriterio.Guardar();
                }
                ViewBag.EvidenciaCriterio = objEvidenciaCriterio.Listar();
                return Redirect("~/Evidencia");
            }
            else
            {
                return View("~/Views/Evidencia/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id, string archivo_elim)
        {
            objEvidencia.evidencia_id = id;
            objEvidencia.Eliminar();
            archivo_elim = Server.MapPath(archivo_elim);
            System.IO.File.Delete(@archivo_elim);
            return Redirect("~/Evidencia");
        }

        public void subirArchivo(HttpPostedFileBase file, string codigoEvidencia)
        {
            if(file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/App_Data/Archivos"), Path.GetFileNameWithoutExtension(fileName) + "__" + codigoEvidencia + Path.GetExtension(fileName));
                file.SaveAs(path);
            }
        }
    }
}