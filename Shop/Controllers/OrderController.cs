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
		// TODO make POST
        public ActionResult Index()
        {
            //var unit = DB.DataProvider.Instance.GetAllUnits().First(u => u.Id.ToString().Equals(unitId));
            OrderModel orderModel = new OrderModel();
            var dict = new Dictionary<int, int>();
            if (Session[Constants.SESSEION_BASKET] is Dictionary<int, int>)
                dict = Session[Constants.SESSEION_BASKET] as Dictionary<int, int>;
            foreach (var item in dict)
            {
                ((ObservableCollection<OrderedItemModel>)orderModel.OrderedItems).
                    Add(new OrderedItemModel { UnitId = item.Key, Quantity = item.Value });
            }

	        return View(orderModel);
        }

	    public ActionResult SubmitOrder(OrderModel order)
	    {
            DataProvider.Instance.CreateOrder(
                order.OrderedItems.Select(o => new UnitOrderRelation { UnitId = o.UnitId, Quantity = o.Quantity }),
                new CustomerInfo(order));
		    return RedirectToAction("Index","Home");
	    }
    }
}
