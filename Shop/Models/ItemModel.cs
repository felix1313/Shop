using System.Collections.Generic;
using Shop.Attributes;
using Shop.TreeRelated;

namespace Shop.Models
{
    public class ItemModel : IIdentifiable, IChild
    {
        private readonly Dictionary<string, UnitPropertyModel> properties = new Dictionary<string, UnitPropertyModel>(); 

        public int Id { get; set; }

        public int? ParentId { get; set; }

        [MyDisplayName("item","name")]
        public string Name { get; set; }

        [MyDisplayName("item","description")]
        public string Description { get; set; }

        [MyDisplayName("item","image")]
        public string ImageSrc { get; set; }

        [MyDisplayName("item","price")]
        public decimal? Price { get; set; }

        public Dictionary<string, UnitPropertyModel> Properties
        {
            get
            {
                return properties;
            }
        }
    }
}