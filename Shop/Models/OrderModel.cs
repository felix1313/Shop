﻿using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Shop.Models
{
    public class OrderModel
    {
        private readonly IEnumerable<OrderedItemModel> orderedItems =
            new ObservableCollection<OrderedItemModel>();

		public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<OrderedItemModel> OrderedItems
        {
            get
            {
                return orderedItems;
            }
        }
    }
}