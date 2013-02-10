using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Scratch.Core;
using System.Web.Mvc;
using System.Web.Http;

namespace Scratch.Core.Controllers
{
    public class EntityApiController<TModel> : ApiController, IEntityApiController<TModel>, IHaveEntity<TModel>        
    {
        public EntityApiController() : this(null)
        {
            
        }
        public EntityApiController(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider ?? new ServiceProvider();
        }
        public TModel Entity { get; set; }
        public IEntityProvider<TModel> ModelProvider { get; set; }
        public IServiceProvider ServiceProvider { get; set; }

        public TModel GetById(Guid id)
        {
            return ModelProvider.QueryById(id);
        }

        public IEnumerable<TModel> Get()
        {
            return ModelProvider.QueryAll();
        }

        public TModel Post(TModel model)
        {
            ModelProvider.Update(model);
            return model;
        }

        public void Delete(Guid id)
        {
            ModelProvider.Delete(id);
        }        
    }
}
