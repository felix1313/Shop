﻿using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class ItemModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageSrc { get; set; }

        public decimal Price { get; set; }
    }
}