using Burk.Core.Abstract.Log;
using System;

namespace Burk.Core.Concrete.Log
{
    public class Log4NetFactory : ILogFactory
    {
        public object GetLogger(Type parentType)
        {
            return (ILog)(new Log(log4net.LogManager.GetLogger(parentType)));
        }
    }
}
