using Burk.Core.Abstract.Unity;
using Microsoft.Practices.Unity;
using System;

namespace Burk.Core.Concrete.Unity
{
    public sealed class UnityObjectFactory : IUnityObjectFactory
    {
        #region FIELDS
        private IUnityContainer container;
        #endregion

        #region CONSTRUCTORS
        public UnityObjectFactory(IUnityContainer container)
        {
            this.container = container;
        }
        #endregion

        #region PROPERTIES
        public IUnityContainer Container { get { return container; } }
        #endregion

        #region METHODS
        public object CreateObject(Type type)
        {
            return container.Resolve(type);
        }

        public T CreateObject<T>() where T : class
        {
            return container.Resolve<T>();
        }

        public object InitializeObject(Type type, object obj)
        {
            return container.BuildUp(type, obj);
        }

        public T InitializeObject<T>(T obj) where T : class
        {
            return container.BuildUp<T>(obj);
        }
        #endregion
    }
}
