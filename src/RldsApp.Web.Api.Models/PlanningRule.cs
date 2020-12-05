using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class PlanningRule : ILinkContaining

    {
        private List<Link> _links;

        [Key]
        public virtual long Id { get; set; }

        public virtual DateTime DateFrom { get; set; }

        public virtual DateTime DateTo { get; set; }

        public virtual User User { get; set; }

        public virtual Account Sender { get; set; }

        public virtual Account Receiver { get; set; }

        public virtual TransactionCategory Category { get; set; }

        public virtual Currency Currency { get; set; }

        public virtual string Description { get; set; }

        public virtual decimal Amount { get; set; }

        public virtual Period Period { get; set; }

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
