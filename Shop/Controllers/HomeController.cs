﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Shop.Helpers;
using Shop.Models;
using Shop.Observers;
using Shop.TreeRelated;

namespace Shop.Controllers
{
    public class HomeController : BaseController
    {
        //
        // GET: /Home/

	    public HomeController()
	    {
			AddObserver(new LoggerObserver());
	    }
        
        public ActionResult Index()
        {
            var treeWIthPeoperties = new TreeWithProperties(
                DisplayModelsProvider.GetItemModelTree(),
                DisplayModelsProvider.GetPropertyModels());
            return View(treeWIthPeoperties);
        }

        public void AddItemToBasket(int itemId)
        {
            if (Session[Constants.SESSION_BASKET] == null)
                Session[Constants.SESSION_BASKET] = new Dictionary<int, OrderedItemModel>();
            var dct = (Dictionary<int, OrderedItemModel>)Session[Constants.SESSION_BASKET];
            if (!dct.ContainsKey(itemId)) 
                dct.Add(itemId, new OrderedItemModel { UnitId = itemId, Quantity = 1 });
            else
                dct[itemId].Quantity++;
	        Notify(ActionFactory.CreateSimpleAction(string.Format("Item {0} was added", itemId)));
        }

        public void SaveSession(int itemId, int quantity)
        {
            if (Session[Constants.SESSION_BASKET] == null)
                Session[Constants.SESSION_BASKET] = new Dictionary<int, OrderedItemModel>();
            var dct = (Dictionary<int, OrderedItemModel>)Session[Constants.SESSION_BASKET];
            if (!dct.ContainsKey(itemId))
                dct.Add(itemId, new OrderedItemModel { UnitId = itemId, Quantity = quantity });
            else
                dct[itemId].Quantity = quantity;
        }
    }
}
