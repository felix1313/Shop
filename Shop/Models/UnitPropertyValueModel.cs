namespace Shop.Models
{
    public class UnitPropertyValueModel
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public int PropertyId { get; set; }

        public string Value { get; set; }
    }
}