using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace Sistema_MVC_Grupo_X
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/LayoutBackend/css").Include(
                "~/Assets/AdminLTE/bower_components/bootstrap/dist/css/bootstrap.min.css",
                "~/Assets/AdminLTE/bower_components/font-awesome/css/font-awesome.min.css",
                "~/Assets/AdminLTE/bower_components/Ionicons/css/ionicons.min.css",
                "~/Assets/AdminLTE/dist/css/AdminLTE.min.css",
                "~/Assets/AdminLTE/dist/css/skins/skin-blue.min.css"

                ));
            bundles.Add(new ScriptBundle("~/LayoutBackend/js").Include(
                 "~/Assets/AdminLTE/bower_components/jquery/dist/jquery.min.js",
                 "~/Assets/AdminLTE/bower_components/bootstrap/dist/js/bootstrap.min.js",
                 "~/Assets/AdminLTE/dist/js/adminlte.min.js"
                ));
            bundles.Add(new StyleBundle("~/LayoutFrontend/css").Include(
                "~/Assets/vendors/bootstrap/bootstrap.min.css",
                "~/Assets/vendors/fontawesome/css/all.min.css",
                "~/Assets/vendors/themify-icons/themify-icons.css",
                "~/Assets/vendors/linericon/style.css",
                "~/Assets/vendors/owl-carousel/owl.theme.default.min.css",
                "~/Assets/vendors/owl-carousel/owl.carousel.min.css",
                "~/Assets/css/style.css"));

            bundles.Add(new ScriptBundle("~/LayoutFrontend/js").Include(
                "~/Assets/vendors/jquery/jquery-3.2.1.min.js",
                "~/Assets/vendors/bootstrap/bootstrap.bundle.min.js",
                "~/Assets/vendors/owl-carousel/owl.carousel.min.js",
                "~/Assets/js/jquery.ajaxchimp.min.js",
                "~/Assets/js/mail-script.js",
                "~/Assets/js/main.js"));
        }
    }
}