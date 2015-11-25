using System.Linq;
using System.Web.Mvc;
using Shop.Models;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index(string unitId)
        {
            //var unit = DB.DataProvider.Instance.GetAllUnits().First(u => u.Id.ToString().Equals(unitId));
            return View(new OrderModel(new ItemModel()));
        }

    }
}
