using System.ComponentModel.DataAnnotations;
using Shop.Attributes;

namespace Shop.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        [MyDisplayName("item","name")]
        public string Name { get; set; }

        [MyDisplayName("item","description")]
        public string Description { get; set; }

        [MyDisplayName("item","image")]
        public string ImageSrc { get; set; }

        [MyDisplayName("item","price")]
        public decimal Price { get; set; }
    }
}