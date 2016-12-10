using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Implementation.Context;

namespace Handel.DataAccess.Impl.Repositories
{
    public abstract class RepositoryBase
    {
        protected ApplicationContext Context;

        protected RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }
    }
}
