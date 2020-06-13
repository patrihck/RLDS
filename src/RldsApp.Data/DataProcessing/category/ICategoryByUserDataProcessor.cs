using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;

namespace RldsApp.Data.DataProcessing.category
{
    public interface ICategoryByUserDataProcessor
    {
        QueryResult<Category> GetCategoryByUser(long userId, PagedDataRequest requestInfo);
    }
}
