using Microsoft.Practices.Unity;
using System;

namespace Burk.Core.Abstract.Unity
{
    /// <summary>
    /// Интерфейс IUnityObjectFactory.
    /// </summary>
    public interface IUnityObjectFactory
    {
        #region Properties
        /// <summary>
        /// Контейнер Unity.
        /// </summary>
        IUnityContainer Container { get; }
        #endregion

        #region Methods
        /// <summary>
        /// Создание объекта из Unity-контейнера.
        /// </summary>
        object CreateObject(Type type);

        /// <summary>
        /// Создание объекта из Unity-контейнера (generic метод).
        /// </summary>
        T CreateObject<T>() where T : class;

        /// <summary>
        /// Заполнения зависимостей из Unity-контейнера для уже созданного объекта.
        /// </summary>
        object InitializeObject(Type type, object obj);

        /// <summary>
        /// Заполнения зависимостей из Unity-контейнера для уже созданного объекта.
        /// </summary>
        T InitializeObject<T>(T obj) where T : class;
        #endregion
    }
}
