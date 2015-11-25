using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class BaseController : Controller
    {
		protected IDisplayModelsProvider DisplayModelsProvider = new DisplayModelsDataBaseProvider();

	    public bool IsUserAuthenticated
	    {
		    get { return Session["user"] != null; }
	    }

		public new RedirectToRouteResult RedirectToAction(string action, string controller)
		{
			return base.RedirectToAction(action, controller);
		}
    }
}
