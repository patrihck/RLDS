using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class TransactionState : IVersionedEntity
    {
        public virtual long TransactionStateId { get; set; }

        public virtual string Name { get; set; }

        public virtual byte[] Version { get; set; }

        public virtual int Ordinal { get; set; }
    }
}
