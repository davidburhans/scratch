using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scratch.Core
{
    public class ServiceProvider : IServiceProvider
    {
        public object GetService(Type serviceType)
        {
            return Activator.CreateInstance(serviceType);
        }
    }
}