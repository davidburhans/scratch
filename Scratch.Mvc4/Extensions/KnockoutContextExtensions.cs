using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PerpetuumSoft.Knockout;

namespace Scratch.Mvc4
{
    public static class KnockoutContextExtensions
    {
        public static KnockoutContext<TModel> Call<TModel, T>(this KnockoutContext<TModel> ko, Func<TModel, T> method)
        {
            return null;
        }
    }
}