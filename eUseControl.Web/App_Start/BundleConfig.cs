using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;

namespace eUseControl.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/cake/css").Include(
      "~/Content/css/bootstrap.min.css",
      "~/Content/css/font-awesome.min.css",
      "~/Content/css/owl.carousel.css",
      "~/Content/css/owl.theme.css",
      "~/Content/css/animate.css",
      "~/Content/css/style.css"));

            bundles.Add(new ScriptBundle("~/bundles/cake/js").Include(
                "~/Content/js/jquery.min.js",
                "~/Content/js/bootstrap.min.js",
                "~/Content/js/owl.carousel.min.js",
                "~/Content/js/wow.min.js",
                "~/Content/js/script.js"));



        }
    }

}


