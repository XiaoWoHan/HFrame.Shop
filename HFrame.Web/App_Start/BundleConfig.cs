using System.Web;
using System.Web.Optimization;

namespace HFrame.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            ///Js
            
            //common
            bundles.Add(new ScriptBundle("~/Js/Common").Include(
                "~/Content/Plugin/Jquery/jquery-{version}.js",
                "~/Content/Plugin/popper/popper.js",
                "~/Content/Plugin/Bootstrap/js/bootstrap.js",
                "~/Content/Plugin/HFrame/js/common.js"));

            bundles.Add(new ScriptBundle("~/Js/Login").Include(
                "~/Content/Plugin/Jquery/jquery-{version}.js",
                "~/Content/Plugin/popper/popper.js",
                "~/Content/Plugin/Bootstrap/js/bootstrap.js",
                "~/Content/Plugin/HFrame/js/common.js"
                ));
            ///Css

            bundles.Add(new StyleBundle("~/Css/Login").Include(
                "~/Content/Plugin/HFrame/css/public.css",
            "~/Content/Plugin/bootstrap/css/bootstrap.css"
                ));

            //Common
            bundles.Add(new StyleBundle("~/Css/Common").Include(
            "~/Content/Plugin/HFrame/css/public.css",
            "~/Content/Plugin/bootstrap/css/bootstrap.css",
            //< !--Main CSS-- >
            "~/Content/Plugin/assets/css/material-dashboard.css"
            //< !--Fonts and icons-- >
            /*"~/Content/Plugin/css/font-css.css"*/));

            BundleTable.EnableOptimizations = true;
        }
    }
}
