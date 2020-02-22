using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RldsApp.Web.Api.Models
{
	public class Account : ILinkContaining
	{
		private readonly IList<User> _users = new List<User>();

		public int AccountId { get; set; }

		//public Currency Currency { get; set; }

		//public Group Group { get; set; }

		//public AccountType AccountType { get; set; }

		public decimal StartAmount { get; set; }

		public IList<User> Users => _users;

		private List<Link> _links;

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
