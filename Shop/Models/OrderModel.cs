using System.Collections.ObjectModel;

namespace Shop.Models
{
    public class OrderModel
    {
		public int Id { get; set; }

        private readonly ObservableCollection<OrderedItemModel> orderedItems =
            new ObservableCollection<OrderedItemModel>();

		public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ObservableCollection<OrderedItemModel> OrderedItems
        {
            get
            {
                return orderedItems;
            }
        }
    }
}