using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
using Sistema_MVC_Grupo_X.Filters;
using System.IO;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class EvidenciaController : Controller
    {
        //instanciar la clase Evidencia
        private Evidencia objEvidencia = new Evidencia();
        
        [Autenticado]
        // GET: Evidencia
        public ActionResult Index()
        {
            
            var path = Server.MapPath(@"~/Upload/");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);


            foreach (var item in directoryInfo.GetFiles())
            {
                objEvidencia.EvidenciaCriterio.Add(new EvidenciaCriterio()
                {
                    archivo = item.Name,
                    tipo = item.Extension,
                    tamanio = item.Length+""
                });

            }
            
            return View("Index",objEvidencia);
        }

        private Criterio objCriterio = new Criterio();
        public ActionResult MostrarCriterio()
        {
            return PartialView(objCriterio.Listar());
        }


        


        public ActionResult Archivo(HttpPostedFileBase file, string totalLink="", int evidencia_id=0)
        {
            FileInfo archivo = new FileInfo(@"~/Upload/"+totalLink);
            archivo.Delete();
            if (file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(@"~/Upload/"), fileName);
                file.SaveAs(path);

            }

            return RedirectToAction("AgregarEditar", new { evidencia_id });
        }
        //Action Visualizar
        public ActionResult Visualizar(int id)
        {
            return View(objEvidencia.Obtener(id));
        }

        //Accion agregarEditar
        public ActionResult AgregarEditar(int id = 0)
        {
            return View(
                id == 0 ? new Evidencia() //Agrega un nuevo objeto
                : objEvidencia.Obtener(id) //Devuelva un objeto
                );
        }

        //Accion guardar
        public ActionResult Guardar(Evidencia objEvidencia)
        {
            if (ModelState.IsValid)
            {
                objEvidencia.Guardar();
                return Redirect("~/Evidencia");
            }
            else
            {
                return View("~/Views/Evidencia/AgregarEditar.cshtml");
            }
        }

        //Accion eliminar
        public ActionResult Eliminar(int id)
        {
            objEvidencia.evidencia_id = id;
            objEvidencia.Eliminar();
            return Redirect("~/Evidencia");
        }
    }
}