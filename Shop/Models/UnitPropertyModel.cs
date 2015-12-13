using Shop.Enums;

namespace Shop.Models
{
    public class UnitPropertyModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int UnitId { get; set; }

        public PropertyType Type { get; set; }

        public UnitPropertyValueModel PropertyValue { get; set; }

        public UnitPropertyModel Clone()
        {
            return (UnitPropertyModel) MemberwiseClone();
        }
    }
}