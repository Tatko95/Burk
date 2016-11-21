using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Unity;
using Burk.Logic.InitBurk;
using Burk.WebUI.Utils;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Burk.Model.Context;
using Microsoft.AspNet.Identity;
using Burk.Model.Users;
using Burk.Model.Users.Init;
using Burk.WebUI.Controllers;
using Burk.Logic.Concrete.Users.Managers;

namespace Burk.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            UnityContainerFactory.UnityContainer.RegisterType<DbContext, ModelContext>(new HierarchicalLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IUserStore<User>, ApplicationUserStore>();
            UnityContainerFactory.UnityContainer.RegisterType<UserManager<User>, ApplicationUserManager>(new HierarchicalLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<AccountController>(new InjectionConstructor());
            UnityContainerFactory.UnityContainer.RegisterType<ManageController>(new InjectionConstructor());
            IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;

            var init = unity.CreateObject<IInitBurk>();
            init.Init();
            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(UnityContainerFactory.UnityContainer));
        }


    }
}
