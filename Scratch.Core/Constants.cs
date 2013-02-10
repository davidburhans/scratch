using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scratch.Core
{
    public class Constants
    {
        public static readonly string GenericRouteName = "type";
        public static readonly string EntityApiRoute = string.Concat("entityapi/{", Constants.GenericRouteName, "}/{id}");
        public static readonly string EntityRoute = string.Concat("entity/{", Constants.GenericRouteName, "}/{action}/{id}/");
    }
}
