using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;
using Handel.DataAccess.Implementation;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Handel.DataAccess.Implementation.Context
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, GuidRole, Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>
    {
        public DbSet<Shop> People { get; set; }

        public ApplicationContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ProxyCreationEnabled = true;
        }

    }
}
