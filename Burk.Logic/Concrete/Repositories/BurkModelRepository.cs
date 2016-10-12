using System;
using System.Collections.Generic;
using Burk.Core.Repository;
using Burk.Logic.Abstract.Repositories;
using Burk.Model.Context;
using Burk.Core.Abstract.Log;
using System.Data.Entity;

namespace Burk.Logic.Concrete.Repositories
{
    public class BurkModelRepository : BaseRepository, IBurkModelRepository
    {
        #region CTOR
        public BurkModelRepository(ILog logger) : base(logger)
        {
            dbContext = new ModelContext();
            dbContext.Database.Initialize(false);
            dbContext.Database.CommandTimeout = 60; //минута
        }
        #endregion
    }
}
