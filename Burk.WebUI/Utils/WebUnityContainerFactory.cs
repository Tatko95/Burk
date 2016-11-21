using Burk.Core.Abstract.Log;
using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Log;
using Burk.Core.Concrete.Unity;
using Burk.Model.Users;
using Burk.Model.Users.Init;
using Microsoft.AspNet.Identity;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Burk.WebUI.Utils
{
    //public class WebUnityContainerFactory
    //{
    //    #region Fields
    //    private static IUnityContainer unityContainer;
    //    #endregion

    //    #region Properties
    //    public static IUnityObjectFactory ObjectFactory
    //    {
    //        get
    //        {
    //            if (unityContainer == null)
    //                unityContainer = CreateUnityContainer();
    //            return unityContainer.Resolve<IUnityObjectFactory>();
    //        }
    //    }

    //    public static IUnityContainer UnityContainer
    //    {
    //        get
    //        {
    //            if (unityContainer == null)
    //                unityContainer = CreateUnityContainer();
    //            return unityContainer;
    //        }
    //    }
    //    #endregion

    //    #region Methods
    //    private static IUnityContainer CreateUnityContainer()
    //    {
    //        UnityContainer unityContainer = new UnityContainer();
    //        unityContainer.AddNewExtension<BuildTrackingExtension>().AddNewExtension<LogCreationExtension<ILog, Log4NetFactory>>(); // инициализация лога log4net
    //        unityContainer.RegisterInstance(unityContainer, new ContainerControlledLifetimeManager());
    //        unityContainer.LoadConfiguration();
    //        unityContainer.RegisterType<IUserStore<User>, ApplicationUserStore>();
    //        return unityContainer;
    //    }
    //    #endregion
    //}
}