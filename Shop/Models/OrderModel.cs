namespace Shop.Models
{
    public class OrderModel
    {
		public int ItemId { get; set; }

        public string CustomerName { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Quantity { get; set; }
    }
}