using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Scratch.Core
{
	public static class IServiceProviderExtensions
	{
        public static T GetService<T>(this IServiceProvider serviceProvider)
        {
            return (T)serviceProvider.GetService(typeof(T));
        }

        public static TModel CreateModel<TModel>(this IServiceProvider serviceProvider)
        {
            return (TModel)serviceProvider.GetService(typeof(TModel));
        }
	}
}