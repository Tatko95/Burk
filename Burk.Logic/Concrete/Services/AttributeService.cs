﻿using Burk.Core.Service;
using Burk.Logic.Abstract.Repositories;
using Burk.Logic.Abstract.Services;
using Burk.Model.UDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Burk.Logic.Concrete.Services
{
    public class AttributeService : BaseService<DossierAttribute>, IAttributeService
    {
        #region CTOR
        public AttributeService(IBurkModelRepository repo) : base(repo) { }
        #endregion

        #region Methods
        public DossierAttribute InsertAttribute(DossierAttribute attr)
        {
            ConfigurateAttributeIndexType(attr);
            repository.Insert(attr);
            return attr;
        }

        private void ConfigurateAttributeIndexType(DossierAttribute attr)
        {
            if (attr.AttributeType == AttributeType.Text)
            {
                var texts = repository.Table<DossierAttribute>().Where(x => x.DosInsetId == attr.DosInsetId && x.AttributeTypeName.Contains("Text")).Select(x => x.AttributeTypeIndex);
                for (int i = 1; i < 20; i++)
                {
                    if (!texts.Contains(i))
                    {
                        attr.AttributeTypeIndex = i;
                        return;
                    }
                }
                throw new Exception("Не вистачає полів в БД");
            }
            else if (attr.AttributeType == AttributeType.Number)
            {
                var numbers = repository.Table<DossierAttribute>().Where(x => x.DosInsetId == attr.DosInsetId && x.AttributeTypeName.Contains("Number")).Select(x => x.AttributeTypeIndex);
                for (int i = 1; i < 20; i++)
                {
                    if (!numbers.Contains(i))
                    {
                        attr.AttributeTypeIndex = i;
                        return;
                    }
                }
                throw new Exception("Не вистачає полів в БД");
            }
            else if (attr.AttributeType == AttributeType.Date)
            {
                var dates = repository.Table<DossierAttribute>().Where(x => x.DosInsetId == attr.DosInsetId && x.AttributeTypeName.Contains("Date")).Select(x => x.AttributeTypeIndex);
                for (int i = 1; i < 10; i++)
                {
                    if (!dates.Contains(i))
                    {
                        attr.AttributeTypeIndex = i;
                        return;
                    }
                }
                throw new Exception("Не вистачає полів в БД");
            }
        }

        public void UpdatePositionAttribute(int attrId, int x, int y)
        {
            var model = GetById("DosAttributeId", attrId.ToString());
            model.X = x;
            model.Y = y;
            repository.Update(model);
        }

        public void UpdateSizeAttribute(int attrId, int width, int height)
        {
            var model = GetById("DosAttributeId", attrId.ToString());
            model.Width = width;
            model.Height = height;
            repository.Update(model);
        }

        public IQueryable<DossierAttribute> GetAllAttributes(int dosInsetId)
        {
            var result = repository.Table<DossierAttribute>().Where(x => x.DosInsetId == dosInsetId);
            return result;
        }
        #endregion
    }
}
