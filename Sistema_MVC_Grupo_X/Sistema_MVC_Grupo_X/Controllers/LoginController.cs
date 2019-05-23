using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema_MVC_Grupo_X.Models;
using Sistema_MVC_Grupo_X.Filters;

namespace Sistema_MVC_Grupo_X.Controllers
{
    public class LoginController : Controller
    {
        private Usuario Usuario = new Usuario();
        [NoLogin]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult Validar(string usuario, string password)
        {
            var rm = Usuario.validarLogin(usuario, password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Default");
            }

            return Json(rm);
        }
        public ActionResult logOut()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}