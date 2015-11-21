using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Shop.DB;
using Shop.Models;
using Shop.Models.AccountViewModels;

namespace WHO.DW.DMT.Models
{
	public class UserStore : IUserStore<User>, IUserPasswordStore<User>
	{
		public Task<User> FindByNameAsync(string userNameOrEmail)
		{
		    return Task.FromResult(DataProvider.Instance.GetAdmin(userNameOrEmail).ToUser());
		}

		public Task<string> GetPasswordHashAsync(User user)
		{
			return Task.FromResult(user.PasswordHash);
		}

		public Task<IList<string>> GetRolesAsync(User user)
		{
            IList<string> list = new List<string>{"Admin"};
		    return Task.FromResult(list);
		}

		public Task<User> FindByIdAsync(string userId)
		{
			return Task.FromResult(DataProvider.Instance.GetAdmin(userId).ToUser());
		}

		public Task CreateAsync(User user)
		{
		    DataProvider.Instance.CreateAdmin(user.UserName, user.PasswordHash);
			return Task.FromResult(0);
		}

		public Task SetPasswordHashAsync(User user, string passwordHash)
		{
			return Task.FromResult(user.PasswordHash = passwordHash);
		}

		public Task DeleteAsync(User user)
		{
		    return Task.FromResult(0);
		}

		public Task UpdateAsync(User user)
		{
			return Task.FromResult(0);
		}

		public Task<bool> HasPasswordAsync(User user)
		{
			return Task.FromResult(!string.IsNullOrEmpty(user.PasswordHash));
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}