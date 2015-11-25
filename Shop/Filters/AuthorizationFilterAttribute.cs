using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Controllers;

namespace Shop.Filters
{
	public class AuthorizationFilterAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			base.OnActionExecuting(filterContext);
			var baseController = (BaseController) filterContext.Controller;
			if (baseController.IsUserAuthenticated == false)
			{
				filterContext.Result = baseController.RedirectToAction("Login", "Account");
			}
		}
	}
}