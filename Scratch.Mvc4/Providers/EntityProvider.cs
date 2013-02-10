using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Scratch.Core;

namespace Scratch.Mvc4.Providers
{
    public class EntityProvider<TEntity> : IEntityProvider<TEntity>
    {
        public void Update(TEntity model)
        {
            throw new NotImplementedException();
        }

        public TEntity Create()
        {
            return Activator.CreateInstance<TEntity>();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public TEntity QueryById(Guid id)
        {
            return Activator.CreateInstance<TEntity>();
        }

        public IEnumerable<TEntity> QueryAll()
        {
            return new TEntity[] { Activator.CreateInstance<TEntity>() };
        }
    }
}