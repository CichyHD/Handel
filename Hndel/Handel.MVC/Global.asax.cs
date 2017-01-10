using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Handel.Core.Contracts;
using Handel.Core.Misc;
using Handel.DataAccess.Contract;
using Handel.DataAccess.Contract.AbstractFactories;
using Handel.DataAccess.Contract.IRepository;
using Handel.DataAccess.Contract.Services;
using Handel.DataAccess.Contract.UserManagers;
using Handel.DataAccess.Impl.Repositories;
using Handel.DataAccess.Impl.Services;
using Handel.DataAccess.Impl.UserManagers;
using Handel.DataAccess.Implementation;
using Handel.DataAccess.Implementation.Context;
using Handel.MVC.Infrastructure.IoC;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;

namespace Handel.MVC
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            RegisterComponents();
        }

        private static void RegisterComponents()
        {
            IoC.Container.AddFacility<TypedFactoryFacility>();
            var castleControllerFactory = new WindsorControllerFactory(IoC.Container);
            ControllerBuilder.Current.SetControllerFactory(castleControllerFactory);

            IoC.Container.Install(new ApplicationCastleInstaller());

            GlobalConfiguration.Configuration.Services.Replace(
                typeof(IHttpControllerActivator),
                new WindsorApiControllerFactory(IoC.Container));

            IoC.Container.Register(Component.For<DbContext>().ImplementedBy<ApplicationContext>().LifestyleTransient()
                .DependsOn(
                    Dependency.OnValue("connectionString", ApplicationVariables.ConnectionStringName)));

            IoC.Container.Register(
                Component.For<IRoleStore<GuidRole, Guid>>()
                    .ImplementedBy<RoleStore<GuidRole, Guid, GuidUserRole>>()
                    .LifestyleTransient());
            IoC.Container.Register(Component.For<RoleManager<GuidRole, Guid>>().LifestyleTransient());

            IoC.Container.Register(
                Component.For<IdentityFactoryOptions<ApplicationUserManager>>().UsingFactoryMethod(() =>
                    new IdentityFactoryOptions<ApplicationUserManager>
                    {
                        DataProtectionProvider = new DpapiDataProtectionProvider("ApplicationName")
                    }
                    ));

            IoC.Container.Register(
                Component.For<IUserManager>().ImplementedBy<ApplicationUserManager>().LifestyleTransient());
            IoC.Container.Register(
                Component.For<ISignInManager>().ImplementedBy<ApplicationSignInManager>().LifestyleTransient());
            
            IoC.Container.Register(
                Component.For<IAuthenticationManager>()
                    .UsingFactoryMethod(AuthenticationMangerFactory.CreateAuthManagerStatic).LifestylePerWebRequest());

            IoC.Container.Register(Component.For<IApplicationUser>().ImplementedBy<ApplicationUser>().LifestyleTransient());
            IoC.Container.Register(Component.For<IAccountService>().ImplementedBy<AccountService>().LifestyleTransient());
            IoC.Container.Register(
                Component.For<IFloatTestService>().ImplementedBy<FloatTestService>().LifestyleTransient());
            IoC.Container.Register(
                Component.For(typeof(IGenericRepository<,>))
                    .ImplementedBy(typeof(GenericRepository<,>))
                    .LifestyleTransient());
           // IoC.Container.Register(
             //   Component.For<IShopRepository>().ImplementedBy<ShopRepository>().ImplementedBy<ApplicationContext>().LifestyleTransient());
            IoC.Container.Kernel.Register(Component.For<IApplicationUserFactory>().AsFactory().LifestylePerWebRequest());
            
        }
    }
}
