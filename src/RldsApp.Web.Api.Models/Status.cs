﻿using System.Collections.Generic;

namespace RldsApp.Web.Api.Models
{
    public class Status : ILinkContaining
    {
        public long StatusId { get; set; }
        public string Name { get; set; }
        public int Ordinal { get; set; }


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
