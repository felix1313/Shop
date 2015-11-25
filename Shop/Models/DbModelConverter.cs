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
				Price = unit.Price
			};
		}
	}
}