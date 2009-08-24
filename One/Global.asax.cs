using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace One
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "Pagination",                                              // Route name
            //    "page/{page}/{maxid}",                           // URL with parameters
            //    new { controller = "Default", action = "paging", page = 1, maxid = long.MinValue }  // Parameter defaults
            //);

            routes.MapRoute(
                "About",                                                        // Route name
                "About/{section}",                                               // URL with parameters
                new { controller = "About", action = "Index", section = ""}     // Parameter defaults
            );

            routes.MapRoute(
                "Default",                                              // Route name
                "{section}/{page}",                           // URL with parameters
                new { controller = "Default", action = "Index", section = "", page = 1 }  // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
    }
}