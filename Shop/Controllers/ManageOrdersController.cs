using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop.Controllers
{
    public class ManageOrdersController : Controller
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
