using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace RldsApp.Web.Api.Models
{
	public class AccountType
	{
		[Required(AllowEmptyStrings = false)]
		public long AccountTypeId { get; set; }
	
		[Editable(false)]
		public int? UserId { get; set; }
		
		[Required(AllowEmptyStrings = false)]
		public string Name { get; set; }
	
		[Editable(true)]
		public string Description { get; set; }

	}
}
