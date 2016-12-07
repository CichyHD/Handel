using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handel.DataAccess.Contract.Misc
{
    public interface IIdentityResult
    {
        IIdentityResult Success { get; }
        IEnumerable<string> Errors { get; }
        bool Succeeded { get; }
        IIdentityResult Failed(params string[] errors);
    }
}
