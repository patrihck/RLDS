using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	public class Daily
    {
        public virtual long DailyId { get; set; }
        public virtual int Hour { get; set; }
    }
}
