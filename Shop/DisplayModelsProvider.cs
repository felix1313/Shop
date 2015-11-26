using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.DB;
using Shop.Models;

namespace Shop
{
	public class DisplayModelsDataBaseProvider : IDisplayModelsProvider
	{
		private readonly DataProvider _dataProvider = DataProvider.Instance;

		public IEnumerable<ItemModel> GetItemModels()
		{
			return _dataProvider.GetAllUnits().Select(u => u.ToItemModel());
		}

		public void AddItem(ItemModel itemModel)
		{
			_dataProvider.AddUnit(itemModel.ToDbModel());
		}

		public void SaveOrder(OrderModel order)
		{
			_dataProvider.CreateOrder(
			   order.OrderedItems.Select(o => new UnitOrderRelation { UnitId = o.UnitId, Quantity = o.Quantity }),
			   new CustomerInfo(order));
		}
	}
}