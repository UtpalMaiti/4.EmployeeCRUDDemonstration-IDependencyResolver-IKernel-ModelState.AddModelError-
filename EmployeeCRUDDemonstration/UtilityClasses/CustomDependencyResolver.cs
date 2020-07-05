using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;

namespace EmployeeCRUDDemonstration.UtilityClasses
{
    public class CustomDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        object IDependencyResolver.GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        IEnumerable<object> IDependencyResolver.GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}