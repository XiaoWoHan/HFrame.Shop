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
                "~/Content/Plugin/SeaJs/sea.js",
                "~/Content/Plugin/HFrameJS/js/CommonJS.js"));

            bundles.Add(new StyleBundle("~/Css/Common").Include(
                "~/Content/Plugin/HFrameJS/css/public.css",
                "~/Content/Plugin/bootstrap/css/bootstrap.css"
            ));
            #endregion

            #region 管理界面引用
            bundles.Add(
                new ScriptBundle("~/Js/Main").Include()
                
                );

            bundles.Add(new StyleBundle("~/Css/Main").Include(
            "~/Content/Plugin/assets/css/material-dashboard.css",
            "~/Content/Plugin/css/font-css.css"));
            #endregion
            BundleTable.EnableOptimizations = true;
        }
    }
}
