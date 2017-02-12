using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.Misc;
using Burk.Model.Resources;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Logic.Concrete.Services
{
    public class InsetService : BaseService<DossierInset>, IInsetService
    {
        #region CTOR
        public InsetService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Lists
        public List<MenuItem> GetInsetItems(int dossierId)
        {
            var insets = repository.Table<DossierInset>().Where(x => x.DosObjectId == dossierId).OrderBy(x => x.Index);
            List<MenuItem> result = new List<MenuItem>();
            foreach (var inset in insets)
                result.Add(new MenuItem() { id = inset.DosInsetId, parentid = -1, text = inset.FullName });
            return result;
        }

        public List<MenuItem> GetInsetItemsForSettings(int dossierId)
        {
            List<MenuItem> listItemsMenu = GetInsetItems(dossierId);
            List<MenuItem> result = new List<MenuItem>();
            int i = 0;
            foreach (var itemMenu in listItemsMenu)
            {
                result.Add(itemMenu);
                result.Add(new MenuItem() { id = (itemMenu.id * 10000 + 1), parentid = itemMenu.id, text = Resource.Edit });
                result.Add(new MenuItem() { id = (itemMenu.id * 10000 + 2), parentid = itemMenu.id, text = Resource.Delete });
                if (i != 0)
                    result.Add(new MenuItem() { id = (itemMenu.id * 10000 + 3), parentid = itemMenu.id, text = Resource.Left });
                if (i != listItemsMenu.Count - 1)
                    result.Add(new MenuItem() { id = (itemMenu.id * 10000 + 4), parentid = itemMenu.id, text = Resource.Right });
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
        public void Upsert(DossierInset model)
        {
            if (model.DosInsetId == 0)
            {
                var insets = repository.Table<DossierInset>().Where(x => x.DosObjectId == model.DosObjectId).OrderByDescending(x => x.Index);
                if (!insets.Any())
                    model.Index = 1;
                else
                    model.Index = insets.First().Index + 1;

                Insert(model);
            }
            else
                Update(model);
        }
        #endregion

        #region UpDownMenuItem
        public void LeftInsetItem(int insetId)
        {
            repository.BeginTransaction();
            try
            {
                var model = GetById("DosInsetId", insetId.ToString());
                var modelEnemy = repository.Table<DossierInset>().Where(x => x.DosObjectId == model.DosObjectId && x.Index < model.Index).OrderByDescending(x => x.Index).First();
                int helpIndex = model.Index;
                model.Index = modelEnemy.Index;
                modelEnemy.Index = helpIndex;
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

        public void RightInsetItem(int insetId)
        {
            repository.BeginTransaction();
            try
            {
                var model = GetById("DosInsetId", insetId.ToString());
                var modelEnemy = repository.Table<DossierInset>().Where(x => x.DosObjectId == model.DosObjectId && x.Index > model.Index).OrderBy(x => x.Index).First();
                int helpIndex = model.Index;
                model.Index = modelEnemy.Index;
                modelEnemy.Index = helpIndex;
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
