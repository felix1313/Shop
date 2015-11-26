using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Shop.Models.AccountViewModels;

namespace Shop.Models
{
	public static class DbModelConverter
	{
		public static ItemModel ToItemModel(this Unit unit)
		{
			return new ItemModel
			{
				Description = unit.Description,
				Id=unit.Id,
				ImageSrc = unit.ImageSrc,
				Price = unit.Price,
				Name = unit.Name
			};
		}

		public static Unit ToDbModel(this ItemModel itemModel)
		{
			return new Unit{
				Description = itemModel.Description,
				ImageSrc = itemModel.ImageSrc,
				Price = itemModel.Price,
				Name = itemModel.Name
			};
		}

		public static OrderedItemModel ToOrderedItemModel(this UnitOrderRelation relation)
		{
			return new OrderedItemModel
			{
				UnitId = relation.UnitId,
				Quantity = relation.Quantity
			};
		}

		public static OrderModel ToOrderModel(this Order order)
		{
			var res = new OrderModel
			{
				Email = order.Email,
				Address = order.Address,
				Phone = order.Phone,
				CustomerName = order.CustomerName,
				Id=order.Id

			};

			foreach (var it in order.UnitOrderRelations.Select(r => r.ToOrderedItemModel()))
			{
				res.OrderedItems.Add(it);
			}

			return res;
		}
	}
}