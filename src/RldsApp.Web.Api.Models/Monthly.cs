using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RldsApp.Web.Api.Models
{
    public class Monthly : ILinkContaining
    {
		private List<Link> _links;

		public virtual long MonthlyId { get; set; }
        public virtual int Month { get; set; }

		[Editable(false)]
		public List<Link> Links
		{
			get { return _links ?? (_links = new List<Link>()); }
			set { _links = value; }
		}

		public void AddLink(Link link)
		{
			Links.Add(link);
		}
	}
}
