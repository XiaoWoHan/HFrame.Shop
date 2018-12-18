using System.Web;
using System.Web.Optimization;

namespace HFrame.Web
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region 全局
            bundles.Add(new ScriptBundle("~/Js/Common").Include(
                "~/Content/Plugin/Jquery/jquery-{version}.js",
                "~/Content/Plugin/popper/popper.js",
                "~/Content/Plugin/Bootstrap/js/bootstrap.js",
                "~/Content/Plugin/HFrameJS/test/js/CommonJS.js"));

            bundles.Add(new StyleBundle("~/Css/Common").Include(
                "~/Content/Plugin/HFrameJS/css/public.css",
                "~/Content/Plugin/bootstrap/css/bootstrap.css"
            ));
            #endregion

            #region 管理界面引用
            bundles.Add(new ScriptBundle("~/Js/Main").Include(
                "~/Content/Plugin/Jquery/jquery-{version}.js",
                "~/Content/Plugin/popper/popper.js",
                "~/Content/Plugin/Admin/Js/bootstrap-material-design.min.js",
                "~/Content/Plugin/Admin/Js/perfect-scrollbar.jquery.min.js",
                "~/Content/Plugin/Admin/Js/bootstrap-notify.js",
                "~/Content/Plugin/Admin/Js/material-dashboard.js",
                "~/Content/Plugin/HFrameJS/test/js/CommonJS.js"
                ));

            bundles.Add(new StyleBundle("~/Css/Main").Include(
                "~/Content/Plugin/Admin/css/icon.css",
                "~/Content/Plugin/Admin/css/material-dashboard.css"
                ));
            #endregion
            BundleTable.EnableOptimizations = true;
        }
    }
}
