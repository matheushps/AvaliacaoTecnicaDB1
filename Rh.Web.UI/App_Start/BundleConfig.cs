using System.Web;
using System.Web.Optimization;

namespace Rh.Web.UI
{
    public class BundleConfig
    {
        // Para mais informações sobre o agrupamento, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para produzir, utilize a ferramenta de compilação em http://modernizr.com para selecionar apenas os testes de que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/lumino.glyphs.js",
                      "~/Scripts/bootstrap-table.js",
                      "~/Scripts/chart.min.js",
                      "~/Scripts/chart-data.js",
                      "~/Scripts/easypiechart.js",
                      "~/Scripts/easypiechart-data.js",
                      "~/Scripts/bootstrap-datepicker.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-table.css",
                      "~/Content/datepicker3.css",
                      "~/Content/styles.css",
                      "~/Content/site.css"));
        }
    }
}
