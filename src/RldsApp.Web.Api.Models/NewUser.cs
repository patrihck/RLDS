using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewUser
	{
		[Required]
		public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Firstname { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Lastname { get; set; }

        [Required]
        public string Email { get; set; }

        public List<Role> Roles { get; set; }
    }
}
