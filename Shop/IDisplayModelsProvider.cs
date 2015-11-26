using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models;

namespace Shop
{
	public interface IDisplayModelsProvider
	{
		IEnumerable<ItemModel> GetItemModels();

		void AddItem(ItemModel itemModel);

		void SaveOrder(OrderModel order);
	}
}