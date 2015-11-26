using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shop.Filters;
using Shop.Observers;

namespace Shop.Controllers
{
	[AuthorizationFilter]
    public class ManageOrdersController : BaseController
    {
        //
        // GET: /ManageOrders/

		public ManageOrdersController()
		{
			AddObserver(new LoggerObserver());
		}

		public ActionResult Index()
		{
			var orders = DisplayModelsProvider.GetNewOrders();

            return View(orders);
        }

        public ActionResult Confirm(int orderId)
        {
            DisplayModelsProvider.ConfirmOrder(orderId);
	        return RedirectToAction("Index");
        }

        public ActionResult DeclineOrder()
        {
            return View();
        }
    }
}
