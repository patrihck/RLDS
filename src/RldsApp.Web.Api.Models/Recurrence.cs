using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class Recurrence
    {
        [Key]
        public virtual long Id { get; set; }

        [Editable(true)]
        public virtual Group Group { get; set; }

        [Editable(true)]
        public virtual byte[] Version { get; set; }
    }
}
