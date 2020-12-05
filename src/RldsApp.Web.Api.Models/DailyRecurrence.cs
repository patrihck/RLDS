using System;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class DailyRecurrence : Recurrence
    {
        [Editable(true)]
        public virtual TimeSpan Time { get; set; }
    }
}
