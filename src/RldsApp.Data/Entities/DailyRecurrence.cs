using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	public class DailyRecurrence
    {
        public virtual long Id { get; set; }
        public virtual TimeSpan Time { get; set; }
    }
}
