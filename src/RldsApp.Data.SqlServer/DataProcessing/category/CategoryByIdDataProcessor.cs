using NHibernate;
using RldsApp.Data.DataProcessing.category;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.category
{
    public class CategoryByIdDataProcessor : ICategoryByIdDataProcessor
    {
        private readonly ISession _session;

        public CategoryByIdDataProcessor(ISession session)
        {
            _session = session;
        }

        public Category GetCategoryById(long categoryId)
        {
            var category = _session.Get<Category>(categoryId);
            return category;
        }
    }
}
