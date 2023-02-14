using System.Web;
using System.Web.Optimization;

namespace CitasConsultorio
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                      "~/Scripts/moment-with-locales.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/datetimepicker").Include(
                      "~/Scripts/bootstrap-datetimepicker.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/alertify").Include(
                      "~/Scripts/alertifyjs/alertify.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui/jquery-ui.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-datetimepicker.min.css",
                      "~/Scripts/alertifyjs/css/alertify.min.css",
                      "~/Scripts/alertifyjs/css/themes/bootstrap.min.css",
                      "~/Scripts/jquery-ui/jquery-ui.min.css",
                      "~/Scripts/jquery-ui/jquery-ui.theme.min.css",
                      "~/Content/Site.css"));

        }
    }
}
