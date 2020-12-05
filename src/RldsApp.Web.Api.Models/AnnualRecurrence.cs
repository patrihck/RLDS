using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class AnnualRecurrence : Recurrence
    {
        [Editable(true)]
        public virtual bool January { get; set; }

        [Editable(true)]
        public virtual bool February { get; set; }

        [Editable(true)]
        public virtual bool March { get; set; }

        [Editable(true)]
        public virtual bool April { get; set; }

        [Editable(true)]
        public virtual bool May { get; set; }

        [Editable(true)]
        public virtual bool June { get; set; }

        [Editable(true)]
        public virtual bool July { get; set; }

        [Editable(true)]
        public virtual bool August { get; set; }

        [Editable(true)]
        public virtual bool September { get; set; }

        [Editable(true)]
        public virtual bool October { get; set; }

        [Editable(true)]
        public virtual bool November { get; set; }

        [Editable(true)]
        public virtual bool December { get; set; }
    }
}
