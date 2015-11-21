using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.AccountViewModels
{
	public class RegisterViewModel
	{
		[Required]
		[StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long", MinimumLength = 2)]
		[RegularExpression(@"^[^@]+$", ErrorMessage = "Login can not contain @")]
		[DisplayName("Name")]
		public string UserName { get; set; }

		[Required]
		[DisplayName("Full name")]
		public string FullName { get; set; }

		[Required]
		[EmailAddress]
		[DataType(DataType.EmailAddress)]
		[DisplayName("Email")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters lonng", MinimumLength = 2)]
		[DataType(DataType.Password)]
		[DisplayName("Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
		[DisplayName("Confirm password")]
		public string ConfirmPassword { get; set; }
	}
}