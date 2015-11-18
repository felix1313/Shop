namespace Shop.Models
{
    public class OrderModel
    {
        private readonly ItemModel orderedItem;

        public OrderModel(ItemModel orderedItem)
        {
            this.orderedItem = orderedItem;
        }

        public ItemModel OrderedItem
        {
            get
            {
                return orderedItem;
            }
        }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Quantity { get; set; }
    }
}