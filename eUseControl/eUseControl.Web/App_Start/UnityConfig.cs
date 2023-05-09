using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using eUseControl.BusinessLogic;
using System.Web.Http;
using System.Web.Mvc;

namespace eUseControl.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ICupcakesService, CupcakesService>();
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IOrdersService, OrdersService>();

            container.RegisterType<IOrderedCupcakesService, OrderedCupcakesService>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);


        }
    }
}