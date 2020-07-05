using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using EmployeeCRUDDemonstration.UtilityClasses;

namespace EmployeeCRUDDemonstration
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //DependencyResolver.SetResolver(new CustomDependencyResolver());

            //while (true)
            //{
            //    Debug.WriteLine("While Block is running ");

            //    Thread.Sleep(10000);
            //}

            Debug.WriteLine("Application_Start running ");
        }
    }
}