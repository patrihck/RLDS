using System.ComponentModel.DataAnnotations;

namespace RldsApp.Web.Api.Models
{
    public class NewRole
    {
        [Required(AllowEmptyStrings = false)]
        public string RoleName { get; set; }
    }
}
