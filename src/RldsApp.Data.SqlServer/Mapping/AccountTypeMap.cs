using FluentNHibernate.Mapping;
using RldsApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.SqlServer.Mapping
{
    public class AccountTypeMap : VersionedClassMap<AccountType>
    {
        public AccountTypeMap()
        {
            Id(x => x.AccountTypeId);
            Map(x => x.Name).Not.Nullable();
            Map(x => x.Description).Not.Nullable();
            References(x => x.User, "UserId");
        }
    }
}
