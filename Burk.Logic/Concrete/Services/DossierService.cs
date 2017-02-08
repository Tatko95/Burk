using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.UDB;
using System.Collections.Generic;
using System.Linq;
using Burk.Model.Misc;
using Burk.Model.Resources;
using System;

namespace Burk.Logic.Concrete.Services
{
    public class DossierService : BaseService<DossierObject>, IDossierService
    {
        #region CTOR
        public DossierService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Menu
        public List<MenuItem> GetMenuItems(int systemId)
        {
            var dossiers = repository.Table<DossierObject>().Where(x => x.SystemId == systemId).OrderBy(x => x.Index);
            List<MenuItem> result = new List<MenuItem>();
            foreach (var dossier in dossiers)
                result.Add(new MenuItem() { id = dossier.DosObjectId, parentid = -1, text = dossier.FullName });
            return result;
        }

        public List<MenuItem> GetMenuItemsForSettings(int systemId)
        {
            List<MenuItem> listItemsMenu = GetMenuItems(systemId);
            List<MenuItem> result = new List<MenuItem>();
            int i = 0;
            foreach (var itemMenu in listItemsMenu)
            {
                result.Add(itemMenu);
                result.Add(new MenuItem() { id = (itemMenu.id * 100 + 1), parentid = itemMenu.id, text = Resource.Edit });
                result.Add(new MenuItem() { id = (itemMenu.id * 100 + 2), parentid = itemMenu.id, text = Resource.Delete });
                if (i != 0)
                    result.Add(new MenuItem() { id = (itemMenu.id * 100 + 3), parentid = itemMenu.id, text = Resource.Up });
                if (i != listItemsMenu.Count - 1)
                    result.Add(new MenuItem() { id = (itemMenu.id * 100 + 4), parentid = itemMenu.id, text = Resource.Down });
                i++;
            }
            if (result.Count < 100)
            {
                MenuItem addNew = new MenuItem() { id = 0, text = Resource.Add, parentid = -1 };
                result.Add(addNew);
            }
            return result;
        }
        #endregion

        #region CRUD
        public void Upsert(DossierObject model)
        {
            if (model.DosObjectId == 0)
            {
                int maxIndex= repository.Table<DossierObject>().Where(x => x.SystemId == model.SystemId).Count();
                model.Index = maxIndex + 1;
                Insert(model);
            }
            else
                Update(model);
        }
        #endregion

        #region UpDownMenuItem
        public void UpMenuItem(int dossierId)
        {
            repository.BeginTransaction();
            try
            {
                var model = GetById("DosObjectId", dossierId.ToString());
                model.Index = model.Index - 1;
                var modelEnemy = repository.Table<DossierObject>().FirstOrDefault(x => x.SystemId == model.SystemId && x.Index == model.Index);
                modelEnemy.Index = modelEnemy.Index + 1;
                repository.Update(model);
                repository.Update(modelEnemy);
                repository.Commit();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw new Exception("See Inner exception", ex);
            }
        }

        public void DownMenuItem(int dossierId)
        {
            repository.BeginTransaction();
            try
            {
                var model = GetById("DosObjectId", dossierId.ToString());
                model.Index = model.Index + 1;
                var modelEnemy = repository.Table<DossierObject>().FirstOrDefault(x => x.SystemId == model.SystemId && x.Index == model.Index);
                modelEnemy.Index = modelEnemy.Index - 1;
                repository.Update(model);
                repository.Update(modelEnemy);
                repository.Commit();
            }
            catch (Exception ex)
            {
                repository.Rollback();
                throw new Exception("See Inner exception", ex);
            }
        }
        #endregion
    }
}
