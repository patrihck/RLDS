using System.Collections.Generic;
using System.Linq;
using NHibernate;
using RldsApp.Data.DataProcessing.category;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.category
{
    class UpdateCategoryDataProcessor : IUpdateCategoryDataProcessor
    {
        private readonly ISession _session;

        public UpdateCategoryDataProcessor(ISession session)
        {
            _session = session;
        }

        public Category GetUpdatedCategory(long categoryId, Dictionary<string, object> updatedPropertyValueMap)
        {
            var category = GetValidCategory(categoryId);
            var propertyInfos = typeof(Category).GetProperties();

            foreach (var propertyValuePair in updatedPropertyValueMap)
            {
                propertyInfos.Single(x => x.Name == propertyValuePair.Key)
                    .SetValue(category, propertyValuePair.Value);
            }

            _session.SaveOrUpdate(category);
            return category;
        }

        public virtual Category GetValidCategory(long categoryId)
        {
            var category = _session.Get<Category>(categoryId);

            if (category == null)
            {
                throw new RootObjectNotFoundException("Task not found");
            }

            return category;
        }
    }
}
