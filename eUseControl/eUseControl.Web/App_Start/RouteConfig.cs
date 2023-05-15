using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace eUseControl.Web
{
  
        public class RouteConfig
        {
            public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

                routes.MapRoute(
                    name: "About",
                    url: "About",
                    defaults: new { controller = "Home", action = "About" }
                );

                routes.MapRoute(
                    name: "Blog",
                    url: "Blog",
                    defaults: new { controller = "Home", action = "Blog" }
                );

            

                routes.MapRoute(
                    name: "Checkout",
                    url: "Checkout",
                    defaults: new { controller = "Home", action = "Checkout" }
                );

                routes.MapRoute(
                    name: "Class",
                    url: "Class",
                    defaults: new { controller = "Home", action = "Class" }
                );

                routes.MapRoute(
                    name: "Contact",
                    url: "Contact",
                    defaults: new { controller = "Home", action = "Contact" }
                );

                routes.MapRoute(
                    name: "Shop",
                    url: "Shop",
                    defaults: new { controller = "Home", action = "Shop" }
                );

                routes.MapRoute(
                    name: "ShopDetails",
                    url: "ShopDetails",
                    defaults: new { controller = "Home", action = "ShopDetails" }
                );

                routes.MapRoute(
                    name: "ShoppingCart",
                    url: "ShoppingCart",
                    defaults: new { controller = "Home", action = "ShoppingCart" }
                );

                routes.MapRoute(
                name: "DeleteUser",
                url: "Admin/DeleteUser/{id}",
                defaults: new { controller = "Admin", action = "DeleteUser", id = UrlParameter.Optional }
                );
          

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                );
            }
        }
    }
