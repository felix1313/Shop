using System.Linq;
using Shop.Enums;

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
				Name = unit.Name,
                ParentId = unit.ParentId
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

	    public static UnitPropertyModel ToPropertyModel(this UnitProperty property)
	    {
	        return new UnitPropertyModel
	        {
	            Id = property.Id,
                Name = property.Name,
                UnitId = property.UnitId,
                Type = (PropertyType)property.Type
	        };
	    }

        public static UnitProperty ToDbProperty(this UnitPropertyModel property)
        {
            return new UnitProperty
            {
                Id = property.Id,
                Name = property.Name,
                UnitId = property.UnitId,
                Type = (int)property.Type
            };
        }

        public static UnitPropertyValueModel ToPropertyValueModel(this UnitPropertyValue property)
        {
            return new UnitPropertyValueModel
            {
                Id = property.Id,
                PropertyId = property.PropertyId,
                UnitId = property.UnitId,
                Value = property.Value
            };
        }

        public static UnitPropertyValue ToDbPropertyValue(this UnitPropertyValueModel property)
        {
            return new UnitPropertyValue
            {
                Id = property.Id,
                PropertyId = property.PropertyId,
                UnitId = property.UnitId,
                Value = property.Value
            };
        } 
	}
}