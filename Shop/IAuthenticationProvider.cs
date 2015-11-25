using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models.AccountViewModels;

namespace Shop
{
	public interface IAuthenticationProvider
	{
		void AddUser(User user);

		bool TryLogin(User user);

		string GetPasswordHash(string password);
	}
}