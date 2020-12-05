using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Data.Entities
{
	public class AnnualRecurrence
    {
        public virtual long Id { get; set; }
        public virtual bool January { get; set; }
        public virtual bool February { get; set; }
        public virtual bool March { get; set; }
        public virtual bool April { get; set; }
        public virtual bool May { get; set; }
        public virtual bool June { get; set; }
        public virtual bool July { get; set; }
        public virtual bool August { get; set; }
        public virtual bool September { get; set; }
        public virtual bool October { get; set; }
        public virtual bool November { get; set; }
        public virtual bool December { get; set; }
    }
}
