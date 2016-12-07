using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.DataAccess.Implementation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Handel.DataAccess.Implementation.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
    }
}
