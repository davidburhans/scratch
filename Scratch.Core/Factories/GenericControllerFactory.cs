using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Reflection;
using System.Runtime.Caching;

namespace Scratch.Core
{
    public class GenericControllerFactory : DefaultControllerFactory
    {
        static GenericControllerFactory()
        {
            ControllerBuilder.Current.DefaultNamespaces.Add("Scratch.Core.Controllers");                
        }

        public GenericControllerFactory()
        {            
            if(_TypeMap == null)
            {
                _TypeMap = new Dictionary<string, Type>();
                var assemblies = AppDomain.CurrentDomain.GetAssemblies();
                foreach (var assembly in assemblies)
                {
                    foreach (var ns in ControllerBuilder.Current.DefaultNamespaces)
                    {
                        var types = GetTypesInNamespace(assembly, ns);
                        foreach (var t in types)
                        {
                            if (t.Namespace.StartsWith(ns, StringComparison.OrdinalIgnoreCase))
                            {
                                _TypeMap[t.Name] = t;
                            }
                        }

                    }
                }
            }
        }

        private static Dictionary<string, Type> _TypeMap = null;

        private static Type[] GetTypesInNamespace(Assembly assembly, string nameSpace)
        {
            Type[] ret = 
                assembly.GetTypes().Where(t => String.Equals(t.Namespace, nameSpace, StringComparison.Ordinal)).ToArray();
            return ret;
        }

        private static Type FindType(string genericTypeName)
        {
            //Type entityType = null;
            //foreach (var ns in ControllerBuilder.Current.DefaultNamespaces)
            //{
                
            //    var checkType = string.Concat(ns, ".", genericTypeName);
            //    entityType = Type.GetType(checkType);
            //    if (entityType != null)
            //    {
            //        break;
            //    }
            //}
            //return entityType;
            return _TypeMap.Single(kvp => kvp.Key.Equals(genericTypeName, StringComparison.OrdinalIgnoreCase)).Value;
        }

        protected override Type GetControllerType(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            // try to find a controller using the default convention
            var defaultControllerType = base.GetControllerType(requestContext, controllerName);
            if (defaultControllerType != null)
            {
                return defaultControllerType;
            }
            // this could be a generic controller, lets check
            var genericTypeName = requestContext.RouteData.Values[Constants.GenericRouteName] as string;
            Type genericParameterType = FindType(genericTypeName);

            var genericControllerType = FindType(string.Concat(controllerName, "Controller`1"));
            return genericControllerType.MakeGenericType(genericParameterType);
        }

        public override IController CreateController(System.Web.Routing.RequestContext requestContext, string controllerName)
        {
            var defaultController = base.CreateController(requestContext, controllerName);
            return defaultController;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var defaultControllerInstance = base.GetControllerInstance(requestContext, controllerType);
            return defaultControllerInstance;
        }

        protected override System.Web.SessionState.SessionStateBehavior GetControllerSessionBehavior(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            var defaultSessionStateBehaviour = base.GetControllerSessionBehavior(requestContext, controllerType);
            return defaultSessionStateBehaviour;
        }

        public override void ReleaseController(IController controller)
        {
            base.ReleaseController(controller);
        }
        
    }
}