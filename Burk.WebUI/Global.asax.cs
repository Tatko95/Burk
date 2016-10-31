using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Unity;
using Burk.Logic.InitBurk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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

            IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;

            var init = unity.CreateObject<IInitBurk>();
            init.Init();
        }
    }
}
