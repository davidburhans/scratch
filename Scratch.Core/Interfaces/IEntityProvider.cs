using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Scratch.Core;

namespace Scratch.Core
{
    public interface IEntityProvider<TModel> : IProvider<TModel>
    {        
        void Update(TModel model);
        TModel Create();
        void Delete(Guid id);
    }
}
