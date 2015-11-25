using Shop.DB;
using Shop.Models.AccountViewModels;

namespace Shop
{
	public class AuthenticationDbProvider : IAuthenticationProvider
	{
		private readonly DataProvider _dbDataProvider = DataProvider.Instance;

		public void AddUser(User user)
		{
			_dbDataProvider.CreateAdmin(user.Email, user.Password);
		}

		public bool TryLogin(User user)
		{
			var dbuser = _dbDataProvider.GetAdmin(user.Email);
			if (dbuser!=null && GetPasswordHash(user.Password) == dbuser.Password)
			{
				user.Id = dbuser.Id;
				return true;
			}
			else
			{
				return false;
			}
		}

		public string GetPasswordHash(string password)
		{
			return password;
		}
	}
}