using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Scratch.Core
{
    public interface IEntityController<TEntity>
    {
        IEntityProvider<TEntity> EntityProvider {get;set;}

        ActionResult Index();
        ActionResult Edit(Guid? id);
        ActionResult View(Guid id);
    }
}
