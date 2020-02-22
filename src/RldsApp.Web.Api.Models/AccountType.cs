using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace RldsApp.Web.Api.Models
{
	public class AccountType : ILinkContaining
	{
		private List<Link> _links;

		[Required(AllowEmptyStrings = false)]
		public long AccountTypeId { get; set; }
	
		[Editable(false)]
		public int? UserId { get; set; }
		
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }
	
		[Editable(true)]
		public string Description { get; set; }
	
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
