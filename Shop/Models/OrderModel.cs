namespace Shop.Models
{
    public class OrderModel
    {
        private readonly UnitModel orderedItem;

        public OrderModel(UnitModel orderedItem)
        {
            this.orderedItem = orderedItem;
        }

        public UnitModel OrderedItem
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