using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class WeeklyRecurrence : Recurrence
    {
        [Editable(true)]
        public virtual bool Monday { get; set; }

        [Editable(true)]
        public virtual bool Tuesday { get; set; }

        [Editable(true)]
        public virtual bool Wednesday { get; set; }

        [Editable(true)]
        public virtual bool Thursday { get; set; }

        [Editable(true)]
        public virtual bool Friday { get; set; }

        [Editable(true)]
        public virtual bool Saturday { get; set; }

        [Editable(true)]
        public virtual bool Sunday { get; set; }
    }
}
