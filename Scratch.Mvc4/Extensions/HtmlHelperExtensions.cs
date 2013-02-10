using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PerpetuumSoft.Knockout;

namespace Scratch.Mvc4
{
    public static class HtmlHelperExtensions
    {

        public static KnockoutContext<TModel> ko<TModel>(this HtmlHelper<TModel> html)
        {
            KnockoutContext<TModel> context = html.ViewBag.ko;
            if (context == null)
            {
                html.ViewBag.ko = context = html.CreateKnockoutContext<TModel>();
            }
            return context;
        }
    }
}