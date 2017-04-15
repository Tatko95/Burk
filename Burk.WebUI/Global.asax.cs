using Burk.Core.Concrete.Unity;
using Burk.Logic.InitBurk;
using Burk.WebUI.Utils;
using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using Burk.Model.Context;
using Microsoft.AspNet.Identity;
using Burk.Model.Users;
using Burk.Model.Users.Init;
using Burk.WebUI.Controllers;
using Burk.Logic.Concrete.Users.Managers;
using Burk.Core.Repository;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Concrete.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Logic.Concrete.Services;

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

            RegisterTypeInUnity();

            IInitBurk init = UnityContainerFactory.ObjectFactory.CreateObject<IInitBurk>();
            init.Init();

            ControllerBuilder.Current.SetControllerFactory(new UnityControllerFactory(UnityContainerFactory.UnityContainer));
        }
        private void RegisterTypeInUnity()
        {
            UnityContainerFactory.UnityContainer.RegisterType<DbContext, ModelContext>(new HierarchicalLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IUserStore<User>, ApplicationUserStore>();
            UnityContainerFactory.UnityContainer.RegisterType<UserManager<User>, ApplicationUserManager>(new HierarchicalLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<AccountController>(new InjectionConstructor());
            UnityContainerFactory.UnityContainer.RegisterType<ManageController>(new InjectionConstructor());
            
            UnityContainerFactory.UnityContainer.RegisterType<IBaseRepository, BaseRepository>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IBurkModelRepository, BurkModelRepository>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<ISystemService, SystemService>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IInitBurk, InitBurk>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IDossierService, DossierService>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IInsetService, InsetService>(new TransientLifetimeManager());
            UnityContainerFactory.UnityContainer.RegisterType<IDictionaryService, DictionaryService>(new TransientLifetimeManager());
            UnityContainerFactory.unityContainer.RegisterType<IAttributeService, AttributeService>(new TransientLifetimeManager());
            UnityContainerFactory.unityContainer.RegisterType<IValueService, ValueService>(new TransientLifetimeManager());
        }
    }
}
