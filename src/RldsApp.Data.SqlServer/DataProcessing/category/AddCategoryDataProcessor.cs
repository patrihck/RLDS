using NHibernate;
using RldsApp.Data.DataProcessing.category;
using RldsApp.Data.Entities;
using RldsApp.Data.Exceptions;

namespace RldsApp.Data.SqlServer.DataProcessing.category
{
    public class AddCategoryDataProcessor : IAddCategoryDataProcessor
    {
        private readonly ISession _session;

        public AddCategoryDataProcessor(ISession session)
        {
            _session = session;
        }

        public void AddCategory(Category category)
        {
            var user = category.User;
            var persistedUser = _session.Get<User>(user.UserId);

            category.User = persistedUser ?? throw new ChildObjectNotFoundException("User not found");

            _session.SaveOrUpdate(category);
        }
    }
}
