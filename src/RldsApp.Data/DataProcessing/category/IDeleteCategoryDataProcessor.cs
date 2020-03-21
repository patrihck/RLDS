using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace RldsApp.Data.DataProcessing.category
{
    public interface IDeleteCategoryDataProcessor
    {
        bool DeleteCategory(long categoryId);
        bool DeleteCategoriesByUser(long userId);
    }
}
