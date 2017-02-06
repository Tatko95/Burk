using System.Web.Optimization;

namespace Burk.WebUI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region JQuery
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryUI").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new StyleBundle("~/Content/jqueryUIcss").Include(
                        "~/Content/themes/base/jquery-ui.min.css"));
            #endregion

            #region JQWidjets
            bundles.Add(new ScriptBundle("~/bundles/JQWidgets").Include(
                        "~/Scripts/JQWidgets/jqxcore.js",
                        "~/Scripts/JQWidgets/jqxdata.js",
                        "~/Scripts/JQWidgets/jqxbuttons.js",
                        "~/Scripts/JQWidgets/jqxscrollbar.js",
                        "~/Scripts/JQWidgets/jqxmenu.js",
                        "~/Scripts/JQWidgets/jqxcheckbox.js",
                        "~/Scripts/JQWidgets/jqxlistbox.js",
                        "~/Scripts/JQWidgets/jqxdropdownlist.js",
                        "~/Scripts/JQWidgets/jqxloader.js",
                        "~/Scripts/JQWidgets/jqxgrid.js",
                        "~/Scripts/JQWidgets/jqxgrid.sort.js",
                        "~/Scripts/JQWidgets/jqxgrid.pager.js",
                        "~/Scripts/JQWidgets/jqxgrid.selection.js",
                        "~/Scripts/JQWidgets/jqxgrid.edit.js",
                        "~/Scripts/JQWidgets/jqxgrid.columnsresize.js",
                        "~/Scripts/JQWidgets/custom.js",
                        "~/Scripts/JQWidgets/globalization/globalize.js"
                        ));

            bundles.Add(new StyleBundle("~/Content/JQWidgetscss").Include(
                        "~/Content/JQWidgets/jqx.base.css",
                        "~/Content/JQWidgets/jqx.boostrap.css"));
            #endregion

            #region SharedScripts
            bundles.Add(new ScriptBundle("~/bundles/SharedScripts").Include(
            "~/Scripts/Shared/Serialization.js",
            "~/Scripts/Shared/PopUpWindows.js",
            "~/Scripts/Shared/CRUD.js"
            ));
            #endregion

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
