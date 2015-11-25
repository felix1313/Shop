using Shop.DB;

namespace Shop.Models
{
    public class OrderedItemModel
    {
        public int UnitId { get; set; }

        public int Quantity { get; set; }

        public string ItemName 
        {
            get
            {
                return DataProvider.Instance.GetUnitById(UnitId).Name;
            }
        }
    }
}