using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Filters;

namespace Shop.Controllers
{
	[AuthorizationFilter]
    public class ManageOrdersController : BaseController
    {
        //
        // GET: /ManageOrders/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConfirmOrder()
        {
            return View();
        }

        public ActionResult DeclineOrder()
        {
            return View();
        }
    }
}
