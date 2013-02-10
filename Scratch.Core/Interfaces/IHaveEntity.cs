using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scratch.Core
{
    public interface IHaveEntity<TEntity>        
    {
        TEntity Entity { get; set; }
    }
}
