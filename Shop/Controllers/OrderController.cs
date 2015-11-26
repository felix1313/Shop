using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Shop.DB;
using Shop.Helpers;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : BaseController
    {
        //
        // GET: /Order/
        public ActionResult Index()
        {
            OrderModel orderModel = new OrderModel();
            var dict = new Dictionary<int, OrderedItemModel>();
            if (Session[Constants.SESSION_BASKET] is Dictionary<int, OrderedItemModel>)
                dict = Session[Constants.SESSION_BASKET] as Dictionary<int, OrderedItemModel>;
            foreach (var item in dict)
            {
                orderModel.OrderedItems.Add(item.Value);
            }

	        return View(orderModel);
        }

	    public ActionResult SubmitOrder(OrderModel order)
	    {
			DisplayModelsProvider.SaveOrder(order);
	        Session[Constants.SESSION_BASKET] = null;
		    return RedirectToAction("Index","Home");
	    }
    }
}
