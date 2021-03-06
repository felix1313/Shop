﻿using System.Collections.Generic;
using Shop.Models;
using Shop.TreeRelated;

namespace Shop
{
	public interface IDisplayModelsProvider
	{
        IEnumerable<ItemModel> GetItemModels();

        Tree<ItemModel> GetItemModelTree();

	    IEnumerable<UnitPropertyModel> GetPropertyModels();

		void AddItem(ItemModel itemModel);

		void SaveOrder(OrderModel order);
		
		IEnumerable<OrderModel> GetNewOrders();
		void ConfirmOrder(int  id);
	}
}