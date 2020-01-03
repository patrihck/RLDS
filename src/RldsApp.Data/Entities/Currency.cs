using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
    public class Currency : IVersionedEntity
    {
        public int CurrencyId { get; set; }

        public string CurrencyName { get; set; }

        public string CurrencySymbol { get; set; }

        public byte[] Version { get; set ; }
    }
}
