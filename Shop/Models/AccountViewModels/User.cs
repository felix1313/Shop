using Shop.Attributes;

namespace Shop.Models.AccountViewModels
{
    public class User
    {
        public int Id { get; set; }

		[DisplayName("user", "email")]
		public string Email { get; set; }

		[DisplayName("user", "password")]
		public string Password { get; set; }
    }
}