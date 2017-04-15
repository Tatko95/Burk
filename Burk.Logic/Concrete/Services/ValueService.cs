using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.Misc;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Burk.Logic.Concrete.Services
{
    public class ValueService : BaseService<DossierValue>, IValueService
    {
        #region CTOR
        public ValueService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Methods
        public IEnumerable<GridItem> GetGridValuesByDossierId(int dossierId)
        {
            List<GridItem> result = new List<GridItem>();
            IEnumerable<int> mainListsIds = repository.Table<DossierList>().Where(x => x.DosObjectId == dossierId && x.DosListRefId == null).Select(x => x.DosListId);
            IEnumerable<DossierAttribute> attributes = (from inset in repository.Table<DossierInset>().Where(x => x.DosObjectId == dossierId).ToList()
                                                        from attr in repository.Table<DossierAttribute>().Where(x => x.DosInsetId == inset.DosInsetId && x.IsShowInGrid == true).ToList()
                                                        select new DossierAttribute()
                                                        {
                                                            DosAttributeId = attr.DosAttributeId,
                                                            AttributeTypeName = attr.AttributeTypeName,
                                                            AttributeTypeIndex = attr.AttributeTypeIndex,
                                                            DosInsetId = attr.DosInsetId
                                                        }).OrderBy(x => x.DosAttributeId);

            foreach (int mainListId in mainListsIds)
            {
                IEnumerable<DossierList> insetListsId = repository.Table<DossierList>().Where(x => x.DosListRefId == mainListId);
                GridItem gridItem = new GridItem() { };
                gridItem.MainListId = mainListId;
                int i = 0;
                foreach (var insetListId in insetListsId)
                {
                    var resultModel = repository.Table<DossierValue>().FirstOrDefault(x => x.DosListId == insetListId.DosListId);
                    //if (resultModel != null)
                    //{
                    var attributesInset = attributes.Where(x => x.DosInsetId == insetListId.DosInsetId);
                    foreach (var attrInset in attributesInset)
                    {
                        string finder = attrInset.AttributeTypeName + attrInset.AttributeTypeIndex;
                        PropertyInfo propertyValueType = typeof(DossierValue).GetProperty(finder);

                        string propertyName = "Text" + i.ToString();
                        i++;
                        PropertyInfo propertyGrid = typeof(GridItem).GetProperty(propertyName);
                        propertyGrid.SetValue(gridItem, propertyValueType.GetValue(resultModel));
                    }
                    //}
                }
                result.Add(gridItem);
            }

            return result;
        }

        public int InsertValuesWithList(IList<AttributeValue> list, int dossierId)
        {
            repository.BeginTransaction();
            DossierList mainList = CreateMainList(dossierId);
            int insetId = 0;
            DossierList refList;
            DossierValue value = null;
            foreach (var attr in list.OrderBy(x => x.InsetId))
            {
                if (insetId != attr.InsetId)
                {
                    if (value != null)
                        repository.Insert(value);
                    insetId = attr.InsetId;
                    refList = CreateRefList(attr.InsetId, mainList.DosListId);
                    value = new DossierValue() { DosListId = refList.DosListId };
                }
                PropertyInfo prop = typeof(DossierValue).GetProperty(attr.AttributeTypeName + attr.AttributeTypeIndex);
                prop.SetValue(value, attr.Value);
            }
            repository.Insert(value);

            var insets = repository.Table<DossierInset>().Where(x => x.DosObjectId == dossierId);
            foreach (var inset in insets)
            {
                var isInserted = list.FirstOrDefault(x => x.InsetId == inset.DosInsetId);
                if (isInserted == null)
                {
                    refList = CreateRefList(inset.DosInsetId, mainList.DosListId);
                    value = new DossierValue() { DosListId = refList.DosListId };
                    repository.Insert(value);
                }
            }
            repository.Commit();

            return mainList.DosListId;
        }

        public void UpdateValues(IList<AttributeValue> list, int valueId)
        {
            var valueModel = repository.Table<DossierValue>().FirstOrDefault(x => x.DosValueId == valueId);
            foreach (var item in list)
            {
                var property = typeof(DossierValue).GetProperty(item.AttributeTypeName + item.AttributeTypeIndex);
                property.SetValue(valueModel, item.Value);
            }
            repository.Update(valueModel);
        }

        private DossierList CreateMainList(int dossierId)
        {
            DossierList list = new DossierList() { CreateDate = DateTime.Now, DosObjectId = dossierId };
            DossierList insertModel = repository.Insert(list);
            return insertModel;
        }

        private DossierList CreateRefList(int insetId, int mainListId)
        {
            DossierList list = new DossierList() { CreateDate = DateTime.Now, DosInsetId = insetId, DosListRefId = mainListId };
            DossierList insertModel = repository.Insert(list);
            return insertModel;
        }

        public void DeleteValueByMainListId(int mainListId)
        {
            var mainList = repository.Table<DossierList>().FirstOrDefault(x => x.DosListId == mainListId);
            var refLists = repository.Table<DossierList>().Where(x => x.DosListRefId == mainListId);
            repository.BeginTransaction();
            foreach (var refList in refLists)
            {
                DossierValue valueModel = repository.Table<DossierValue>().FirstOrDefault(x => x.DosListId == refList.DosListId);
                repository.Delete(valueModel);
                repository.Delete(refList);
            }
            repository.Delete(mainList);
            repository.Commit();
        }

        public int GetFirstInsetValueIdByMainListId(int mainListId)
        {
            var insets = from refList in repository.Table<DossierList>().Where(x => x.DosListRefId == mainListId)
                         join inset in repository.Table<DossierInset>() on refList.DosInsetId equals inset.DosInsetId
                         where inset.Index == 1
                         join insetList in repository.Table<DossierList>() on inset.DosInsetId equals insetList.DosInsetId
                         where insetList.DosListRefId == mainListId
                         join dosValue in repository.Table<DossierValue>() on insetList.DosListId equals dosValue.DosListId
                         select dosValue;
            return insets.First().DosValueId;
        }

        public int GetInsetIdByValueId(int valueId)
        {
            var insetModel = from value in repository.Table<DossierValue>().Where(x => x.DosValueId == valueId)
                             join list in repository.Table<DossierList>() on value.DosListId equals list.DosListId
                             join inset in repository.Table<DossierInset>() on list.DosInsetId equals inset.DosInsetId
                             select inset;
            return insetModel.First().DosInsetId;
        }

        public int GetValueIdByMainListAndInsetId(int mainListId, int insetId)
        {
            var valueModel = from value in repository.Table<DossierValue>()
                             join refList in repository.Table<DossierList>() on value.DosListId equals refList.DosListId
                             where refList.DosListRefId == mainListId
                             join inset in repository.Table<DossierInset>() on refList.DosInsetId equals inset.DosInsetId
                             where inset.DosInsetId == insetId
                             select value;
            return valueModel.First().DosValueId;
        }
        
        public string GetValueAttrByValueId(int valueId, string typeName, string typeIndex)
        {
            DossierValue valueModel = repository.Table<DossierValue>().FirstOrDefault(x => x.DosValueId == valueId);
            var property = typeof(DossierValue).GetProperty(typeName + typeIndex);
            var returnValue = property.GetValue(valueModel);
            return returnValue == null ? string.Empty : returnValue.ToString();
        }
        #endregion
    }
}
