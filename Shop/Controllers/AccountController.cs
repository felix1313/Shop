using System.Web.Mvc;
using Shop.Models.AccountViewModels;

namespace Shop.Controllers
{
    public class AccountController : BaseController
    {
		private readonly IAuthenticationProvider _authenticationProvider = new AuthenticationDbProvider();

	    public ActionResult Login()
	    {
		    return View();
	    }

	    private const string SessionUserKey = "user";

	    public ActionResult SubmitLogin(User user)
	    {
		    if (_authenticationProvider.TryLogin(user))
		    {
				Session[SessionUserKey] = user.Id;
			    return RedirectToAction("Index", "AdminHome");
		    }
		    else
		    {
			    return RedirectToAction("Login");
		    }
	    }

	    public ActionResult LogOut()
	    {
		    Session[SessionUserKey] = null;
		    return RedirectToAction("Index", "Home");
	    }
    }
}
