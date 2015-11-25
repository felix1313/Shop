using System.Collections.Generic;
using System.Web.Mvc;
using Shop.Helpers;

namespace Shop.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            //return View(new List<ItemModel>());
	        return View(DisplayModelsProvider.GetItemModels());
        }

        public void AddItemToBasket(int itemId)
        {
            if (Session[Constants.SESSEION_BASKET] == null)
                Session[Constants.SESSEION_BASKET] = new Dictionary<int, int>();
            var dct = (Dictionary<int, int>)Session[Constants.SESSEION_BASKET];
            if (!dct.ContainsKey(itemId)) 
                dct.Add(itemId, 1);
            else
                dct[itemId]++;
        }
    }
}
