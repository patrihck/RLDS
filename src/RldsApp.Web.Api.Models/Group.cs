using System;
using System.Collections.Generic;
using System.Text;

namespace RldsApp.Web.Api.Models
{
    public class Group : ILinkContaining
    {
        public virtual int GroupId { get; set; }
        public virtual string Name { get; set; }
        public virtual string Info { get; set; }
        public virtual int Ordinal { get; set; }

        private List<Link> _links;

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