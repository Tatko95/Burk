using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Concrete.Repositories;
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
        //private Mock<IBurkModelRepository> repository;
        private IBurkModelRepository repository;
        public Repository()
        {
            //repository = new BurkModelRepository();
        }

        [TestMethod]
        public void Insert()
        {
            // arrange

            // act
            //var obj = repository.Insert(new Language() { Name = "Ukraine" });

            // assert
            //Assert.IsTrue(repository.Table<Language>().Contains(obj));
        }
    }
}
