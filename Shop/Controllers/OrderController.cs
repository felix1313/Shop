using System.Linq;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/
		// TODO make POST
        public ActionResult Index(int unitId)
        {
            //var unit = DB.DataProvider.Instance.GetAllUnits().First(u => u.Id.ToString().Equals(unitId));
			OrderModel orderModel = new OrderModel
			{
				ItemId = unitId
			};

	        return View(orderModel);
        }

	    public ActionResult SubmitOrder(OrderModel order)
	    {
		    return RedirectToAction("Index","Home");
	    }
    }
}
