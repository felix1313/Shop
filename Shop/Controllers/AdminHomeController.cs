using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Filters;

namespace Shop.Controllers
{
	[AuthorizationFilter]
    public class AdminHomeController : BaseController
    {
        //
        // GET: /AdminHome/

        public ActionResult Index()
        {
            return View();
        }

    }
}
