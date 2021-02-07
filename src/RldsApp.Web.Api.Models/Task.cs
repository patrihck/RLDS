using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
	public class Task : ILinkContaining
	{
		private List<Link> _links;
		private bool _shouldSerializeAssignees;

		[Key]
		public long Id { get; set; }

		[Editable(true)]
		public string Subject { get; set; }

		[Editable(true)]
		public DateTime? StartDate { get; set; }

		[Editable(true)]
		public DateTime? DueDate { get; set; }

		[Editable(false)]
		public DateTime? CreatedDate { get; set; }

		[Editable(false)]
		public DateTime? CompletedDate { get; set; }

		[Editable(false)]
		public TransactionStatus TransactionStatus { get; set; }

		[Editable(false)]
		public List<UserLeaf> Assignees { get; set; }

		[Editable(false)]
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

		public void SetShouldSerializeAssignees(bool shouldSerialize)
		{
			_shouldSerializeAssignees = true; //shouldSerialize;
		}

		public bool ShouldSerializeAssignees()
		{
			return true; //_shouldSerializeAssignees;
		}
	}
}
