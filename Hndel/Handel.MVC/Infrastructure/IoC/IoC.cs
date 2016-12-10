using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Handel.MVC.Infrastructure.IoC
{
    public static class IoC
    {
        private static IWindsorContainer _Container = null;

        static IoC()
        {
            if (_Container == null) _Container = CreateContainer();
        }

        public static void RegisterTypeAndImpl(Type interfaceType, Type implementationType)
        {
            Container.Register(Component.For(interfaceType).ImplementedBy(implementationType).LifeStyle.Transient);

        }

        public static void Register<TInterf, TImpl>()
          where TInterf : class
          where TImpl : TInterf
        {
            RegisterTypeAndImpl(typeof(TInterf), typeof(TImpl));
        }

        public static void Register<TInterf>(TInterf impl) where TInterf : class
        {
            Container.Register(Component.For<TInterf>().Instance(impl));
        }

        private static IWindsorContainer CreateContainer()
        {
            return new WindsorContainer();
        }

        public static IWindsorContainer Container
        {
            get { return _Container; }
        }

        public static IWindsorContainer Register(params IRegistration[] registrations)
        {
            return Container.Register(registrations);
        }

        public static T Resolve<T>()
        {
            return Container.Resolve<T>();
        }

        public static object Resolve(Type service)
        {
            return Container.Resolve(service);
        }

        public static T Resolve<T>(object argumentsAsAnonumousType)
        {
            return Container.Resolve<T>(argumentsAsAnonumousType);
        }

        public static void Release(object instance)
        {
            Container.Release(instance);
        }

        public static void RecreateContainer()
        {
            _Container.Dispose();
            _Container = CreateContainer();
        }
    }
}