using System.ComponentModel.DataAnnotations;
using Shop.Attributes;

namespace Shop.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        [DisplayName("item","name")]
        public string Name { get; set; }

        [DisplayName("item","description")]
        public string Description { get; set; }

        [DisplayName("item","image")]
        public string ImageSrc { get; set; }

        [DisplayName("item","price")]
        public decimal Price { get; set; }
    }
}