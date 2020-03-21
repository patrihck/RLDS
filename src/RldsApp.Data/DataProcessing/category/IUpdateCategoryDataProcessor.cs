using System;
using System.Collections.Generic;
using System.Text;
using RldsApp.Data.Entities;
using PropertyValueMapType = System.Collections.Generic.Dictionary<string, object>;

namespace RldsApp.Data.DataProcessing.category

{
    public interface IUpdateCategoryDataProcessor
    {
        Category GetUpdatedCategory(long categoryId, PropertyValueMapType updatedPropertyValueMap);
    }
}
