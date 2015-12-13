using System.Collections.Generic;
using System.Linq;
using Shop.DB;
using Shop.Models;
using Shop.TreeRelated;

namespace Shop
{
	public class DisplayModelsDataBaseProvider : IDisplayModelsProvider
	{
		private readonly DataProvider dataProvider = DataProvider.Instance;

		public IEnumerable<ItemModel> GetItemModels()
		{
			return dataProvider.GetAllUnits().Select(u => u.ToItemModel());
		}

	    public Tree<ItemModel> GetItemModelTree()
	    {
            var tree = new Tree<ItemModel>(GetItemModels());
	        var propModels = dataProvider.GetAllProperties().Select(p => p.ToPropertyModel());
	        var propValModels = dataProvider.GetAllPropertiyValues().Select(pv => pv.ToPropertyValueModel());
            tree.FillNodePropertyValues(propModels.ToList(), propValModels);
	        return tree;
	    }

	    public IEnumerable<UnitPropertyModel> GetPropertyModels()
	    {
	        return dataProvider.GetAllProperties().Select(p => p.ToPropertyModel());
	    }

		public void AddItem(ItemModel itemModel)
		{
			dataProvider.AddUnit(itemModel.ToDbModel());
		}

		public void SaveOrder(OrderModel order)
		{
			dataProvider.CreateOrder(
			   order.OrderedItems.Select(o => new UnitOrderRelation { UnitId = o.UnitId, Quantity = o.Quantity }),
			   new CustomerInfo(order));
		}

		public IEnumerable<OrderModel> GetNewOrders()
		{
			return dataProvider.GetNewOrders().Select(o => o.ToOrderModel());
		}

		public void ConfirmOrder(int id)
		{
			dataProvider.ConfirmOrder(id);
		}
	}
}