using System.Web.Optimization;

namespace Agenda.UI.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            var estilos = new StyleBundle("~/css");
            var scripts = new ScriptBundle("~/javascript");

            BundleTable.EnableOptimizations = false;

            bundles.Add(
                estilos.Include(
                    "~/Content/bootstrap.css",
                    "~/Content/font-awesome.css",
                    "~/libs/DataTables/jquery.dataTables.css",
                    "~/libs/DataTables/dataTables.bootstrap.css",
                    "~/Content/site.css"
            ));

            bundles.Add(
                scripts.Include(
                    "~/Scripts/modernizr-{version}.js",
                    "~/Scripts/jquery-{version}.js",
                    "~/Scripts/bootstrap.js",
                    "~/Scripts/respond.js",
                    "~/Scripts/jquery.validate*",
                    "~/libs/DataTables/jquery.dataTables.js",
                    "~/libs/DataTables/dataTables.bootstrap.js"
            ));
        }
    }
}
