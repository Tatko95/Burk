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
        private Mock<IBurkModelRepository> repository;

        public Repository()
        {
            repository = new Mock<IBurkModelRepository>();
        }
        [TestMethod]
        public void Repository_Insert_Language()
        {
            // arrange
            //IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;
            //IBurkModelRepository repository = unity.CreateObject<IBurkModelRepository>();
            var language = new Language() { Name = "Ukraine" };
            // act
            var obj = repository.Object.Insert(language);

            // assert
            Assert.IsTrue(repository.Object.Table<Language>().FirstOrDefault(x => x.Name == "Ukraine") != null);
        }
    }
}
