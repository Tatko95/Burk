using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.UDB;
using System.Collections.Generic;
using System.Linq;
using Burk.Model.Misc;
using Burk.Model.Resources;

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
            var dossiers = repository.Table<DossierObject>().Where(x => x.SystemId == systemId);
            List<MenuItem> result = new List<MenuItem>();
            foreach (var dossier in dossiers)
                result.Add(new MenuItem() { id = dossier.DosObjectId, parentid = -1, text = dossier.FullName });
            return result;
        }

        public List<MenuItem> GetMenuItemsForSettings(int systemId)
        {
            List<MenuItem> listItemsMenu = GetMenuItems(systemId);
            List<MenuItem> result = new List<MenuItem>();
            foreach (var itemMenu in listItemsMenu)
            {
                result.Add(itemMenu);
                result.Add(new MenuItem() { id = (itemMenu.id * 100 + 1), parentid = itemMenu.id, text = Resource.Edit });
                result.Add(new MenuItem() { id = (itemMenu.id * 100 + 2), parentid = itemMenu.id, text = Resource.Delete });
            }
            if (result.Count < 100)
            {
                MenuItem addNew = new MenuItem() { id = 0, text = Resource.Add, parentid = -1 };
                result.Add(addNew);
            }
            return result;
        }
        #endregion
    }
}
