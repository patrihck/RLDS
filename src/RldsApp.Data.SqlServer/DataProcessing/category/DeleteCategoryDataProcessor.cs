using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using RldsApp.Data.DataProcessing.category;
using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.DataProcessing.category
{
    public class DeleteCategoryDataProcessor : IDeleteCategoryDataProcessor
    {
        private readonly ISession _session;

        public DeleteCategoryDataProcessor(ISession session)
        {
            _session = session;
        }

        public bool DeleteCategory(long categoryId)
        {
            var result = false;
            var category = _session.Get<Category>(categoryId);

            if (category != null)
            {
                _session.Delete(category);
                _session.Flush();

                result = true;
            }

            return result;
        }

        public bool DeleteCategoriesByUser(long userId)
        {
            var result = false;
            var user = _session.Get<User>(userId);

            if (user != null)
            {
                _session.Query<Category>().Where(x => x.User == user).Delete();
                _session.Flush();

                result = true;
            }

            return result;
        }
    }
}
