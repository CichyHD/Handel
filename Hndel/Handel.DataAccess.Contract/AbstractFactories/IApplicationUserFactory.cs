using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.Contracts;

namespace Handel.DataAccess.Contract.AbstractFactories
{
    public interface IApplicationUserFactory
    {
        IApplicationUser CreateNewUser(string name, string email);
    }
}
