using Burk.Core.Abstract.Log;
using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Unity;
using Burk.Core.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Core
{
    [TestClass]
    public class Unity
    {
        [TestMethod]
        public void Unity_CreateLogger()
        {
            //arrange
            IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;
            ///act
            ILog log = unity.CreateObject<ILog>();
            //assert
            Assert.IsTrue(log != null);
        }
    }
}
