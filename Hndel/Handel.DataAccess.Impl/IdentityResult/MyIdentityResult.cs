using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Contract.Misc;

namespace Handel.DataAccess.Impl.IdentityResult
{
    public class MyIdentityResult : IIdentityResult
    {
        private Microsoft.AspNet.Identity.IdentityResult _msIdentity;

        public MyIdentityResult(Microsoft.AspNet.Identity.IdentityResult msIdentity)
        {
            this._msIdentity = msIdentity;
        }

        public IEnumerable<string> Errors
        {
            get
            {
                return _msIdentity.Errors;
            }
        }

        public bool Succeeded
        {
            get
            {
                return _msIdentity.Succeeded;
            }
        }

        public IIdentityResult Success
        {
            get
            {
                var baseIdentity = Microsoft.AspNet.Identity.IdentityResult.Success;
                return new MyIdentityResult(baseIdentity);
            }
        }

        public IIdentityResult Failed(params string[] errors)
        {
            var baseIdentity = Microsoft.AspNet.Identity.IdentityResult.Failed(errors);
            return new MyIdentityResult(baseIdentity);
        }
    }
}
