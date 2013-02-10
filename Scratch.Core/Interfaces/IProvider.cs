using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scratch.Core
{
    public interface IProvider<TResource>
    {
        TResource QueryById(Guid id);
        IEnumerable<TResource> QueryAll();
    }
}
