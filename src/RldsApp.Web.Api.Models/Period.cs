using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RldsApp.Web.Api.Models
{
    public class Period : ILinkContaining
    {
        private List<Link> _links;

        public virtual long Id { get; set; }
        public virtual Group Group { get; set; }
        public virtual byte[] Version { get; set; }

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
