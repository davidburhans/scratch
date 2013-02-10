using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Scratch.Core;

namespace Scratch.Core
{
    public interface IEntityApiController<TEntity> : IHaveEntity<TEntity>, IAmServiced       
    {
        IEntityProvider<TEntity> ModelProvider { get; set; }

        TEntity GetById(Guid id);
        IEnumerable<TEntity> Get();
        TEntity Post(TEntity model);
        void Delete(Guid id);
    }
}
