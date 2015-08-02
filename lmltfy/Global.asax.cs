using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using lmltfy.Factories;
using lmltfy.Models;

namespace lmltfy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Access the db to JIT the EF dll, and generate a URL to JIT parts of our DLL (improve page loads on subsequent first time app starts)
            using (var db = new lmltfyContext())
            {
                var res = db.SearchModels.FirstOrDefault();
                res = res ?? new SearchModel() ;
                Console.Write(new UrlGeneration().Generate() + res);
            }
           
        }
    }
}
