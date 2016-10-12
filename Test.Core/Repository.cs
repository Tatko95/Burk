using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Unity;
using Burk.Logic.Abstract.Repositories;
using Burk.Model.UDB;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Test.Core
{
    [TestClass]
    public class Repository
    {
        [TestMethod]
        public void Repository_Insert_Language()
        {
            // arrange
            IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;
            IBurkModelRepository repository = unity.CreateObject<IBurkModelRepository>();
            var language = new Language() { Name = "Ukraine" };
            // act
            var obj = repository.Insert(language);

            // assert
            Assert.IsTrue(repository.Table<Language>().FirstOrDefault(x => x.Name == "Ukraine") != null);

            repository.Delete(obj);
        }
    }
}
