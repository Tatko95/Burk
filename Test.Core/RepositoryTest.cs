using Burk.Core.Abstract.Unity;
using Burk.Core.Concrete.Unity;
using Burk.Logic.Abstract.Repositories;
using Burk.Model.UDB;
using Burk.Model.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;

namespace Test.Core
{
    [TestClass]
    public class RepositoryTest
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

        [TestMethod]
        public void RepositoryBigMethod()
        {
            // arrange
            IUnityObjectFactory unity = UnityContainerFactory.ObjectFactory;
            IBurkModelRepository repository = unity.CreateObject<IBurkModelRepository>();
            repository.Insert(new UserInSystem() { SystemId = 1, UserId = "5282d461-e3a6-4031-bd32-17683052ec9c" });

            // act
            var result = from usInSys in repository.Table<UserInSystem>().Where(x => x.UserId == "5282d461-e3a6-4031-bd32-17683052ec9c")
                         join sys in repository.Table<Burk.Model.UDB.System>() on usInSys.SystemId equals sys.SystemId
                         select usInSys;

            //assert

        }
    }
}
