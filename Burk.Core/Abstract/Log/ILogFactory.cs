using System;

namespace Burk.Core.Abstract.Log
{
    /// <summary>
    /// This interface decouples the following classes from any specific logging framework.
    /// </summary>
    public interface ILogFactory
    {
        /// <summary>
        /// This method must return an instance of a Logger.
        /// 
        /// The type of the class that is using the logger.
        /// An instance of a logger.
        /// </summary>
        object GetLogger(Type parentType);
    }
}
