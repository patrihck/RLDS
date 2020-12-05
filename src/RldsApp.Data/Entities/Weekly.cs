using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	public class Weekly
    {
        public virtual long WeeklyId { get; set; }
        public virtual int Day { get; set; }
    }
}
