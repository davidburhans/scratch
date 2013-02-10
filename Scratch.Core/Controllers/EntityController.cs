using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scratch.Core.Controllers
{
    public class EntityController<TEntity> : Controller, IEntityController<TEntity>
    {
        public EntityController(IEntityProvider<TEntity> entityProvider)
        {
            EntityProvider = entityProvider;
        }

        public IEntityProvider<TEntity> EntityProvider { get; set; }

        private ActionResult ModelView<TModel>(TModel model)
        {
            if (Request.IsAjaxRequest())
            {
                return PartialView(model);
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Index()
        {
            var model = new TEntity[]
            {
                default(TEntity)
            };
            return ModelView(model);
        }

        public ActionResult Edit(Guid? id)
        {
            TEntity model;
            if (!id.HasValue)
            {
                model = EntityProvider.Create();
                return ModelView(model);
            }
            else
            {
                model = EntityProvider.QueryById(id.Value);
                return ModelView(model);
            }
        }

        public ActionResult View(Guid id)
        {
            TEntity model = EntityProvider.QueryById(id);
            return ModelView(model);
        }
    }
}
