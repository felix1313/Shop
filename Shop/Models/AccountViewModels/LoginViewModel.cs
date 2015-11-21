using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.AccountViewModels
{
	public class LoginViewModel
	{
		[Required]
		[DisplayName("Name or Email")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }

		[DisplayName("Remember me?")]
		public bool RememberMe { get; set; }
	}
}