using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using lmltfy.Factories;
using lmltfy.Models;
using lmltfy.Database;
using System.Configuration;

namespace lmltfy
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //TODO: constructor inject the azure db into the controllers
       public static DatabaseRepository azuredb = new DatabaseRepository(ConfigurationManager.ConnectionStrings["AzureTable"].ConnectionString, ConfigurationManager.AppSettings["azureTableName"]);
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Access the db to JIT the EF dll, and generate a URL to JIT parts of our DLL (improve page loads on subsequent first time app starts)
#if DEBUG
#else
            Console.WriteLine(azuredb.GetModelByKey("tdszzxr3").Brand);

#endif
        }
    }
}
