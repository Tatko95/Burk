using Burk.Core.Abstract.Log;
using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Log;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Core.Concrete.Unity
{
    public static class UnityContainerFactory
    {
        #region Fields
        private static IUnityContainer unityContainer;
        #endregion

        #region Properties
        public static IUnityObjectFactory ObjectFactory
        {
            get
            {
                if (unityContainer == null)
                    unityContainer = CreateUnityContainer();
                return unityContainer.Resolve<IUnityObjectFactory>();
            }
        }
        #endregion

        #region Methods
        private static IUnityContainer CreateUnityContainer()
        {
            UnityContainer unityContainer = new UnityContainer();
            unityContainer.AddNewExtension<BuildTrackingExtension>().AddNewExtension<LogCreationExtension<ILog, Log4NetFactory>>(); // инициализация лога log4net
            unityContainer.RegisterInstance(unityContainer, new ContainerControlledLifetimeManager());
            unityContainer.LoadConfiguration();
            return unityContainer;
        }
        #endregion
    }
}
