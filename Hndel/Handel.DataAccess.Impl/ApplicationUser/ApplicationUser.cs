﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Handel.Core.BusinessClasses;
using Handel.Core.Contracts;
using Handel.DataAccess.Impl.UserManagers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Handel.DataAccess.Implementation
{
    public class ApplicationUser : IdentityUser<Guid, GuidUserLogin, GuidUserRole, GuidUserClaim>, IApplicationUser
    {
        public string DisplayName { get; set; }
        public T ConvertTo<T>() where T : class, IApplicationUser
        {
            var result = this as T;
            if (result == null)
            {
                throw new InvalidCastException($"This user implementation is diffrent from {nameof(ApplicationUser)}");
            }

            return result;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
        {
            var userIdentity = await (manager).CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class GuidRole : IdentityRole<Guid, GuidUserRole>
    {
        public GuidRole()
        {
            Id = Guid.NewGuid();
        }
        public GuidRole(string name) : this() { Name = name; }
    }

    public class GuidUserRole : IdentityUserRole<Guid>
    {

    }
    public class GuidUserClaim : IdentityUserClaim<Guid>
    {

    }
    public class GuidUserLogin : IdentityUserLogin<Guid>
    {

    }
}
