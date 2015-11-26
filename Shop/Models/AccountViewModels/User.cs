using Shop.Attributes;

namespace Shop.Models.AccountViewModels
{
    public class User
    {
        public int Id { get; set; }

		[MyDisplayName("user", "email")]
		public string Email { get; set; }

		[MyDisplayName("user", "password")]
		public string Password { get; set; }
    }
}