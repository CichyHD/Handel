using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Handel.MVC.Controllers;

namespace Handel.MVC.Infrastructure.IoC
{
    public class ApplicationCastleInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {

            var controllers = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.BaseType == typeof(BaseController) || x.BaseType == typeof(BaseApiController)).ToList();
            foreach (var controller in controllers)
            {
                container.Register(Component.For(controller).LifestylePerWebRequest());
            }
        }
    }
}