using RldsApp.Data.Entities;

namespace RldsApp.Data.SqlServer.Mapping
{
    public class CategoryMap : VersionedClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.CategoryId);

            Map(x => x.Name).Not.Nullable();

            Map(x => x.Description);

            References(x => x.User, "UserId");
        }
    }
}
