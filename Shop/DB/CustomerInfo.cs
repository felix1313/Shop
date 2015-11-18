namespace Shop.DB
{
    public class CustomerInfo
    {
        public CustomerInfo(string name, string email, string phone, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public void FillOrder(Order order)
        {
            order.CustomerName = Name;
            order.Email = Email;
            order.Phone = Phone;
            order.Address = Address;
        }
    }
}