using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using PerpetuumSoft.Knockout;
using Scratch.Core;

namespace Scratch.Mvc4
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //ModelBinders.Binders.DefaultBinder = new KnockoutModelBinder();


            ControllerBuilder.Current.DefaultNamespaces.Add("Scratch.Mvc4.Models");            
            ControllerBuilder.Current.SetControllerFactory(new GenericControllerFactory());
        }
    }
}