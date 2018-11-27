using System;
using System.ComponentModel.DataAnnotations;

namespace CartBusinessLogic.Models
{
    public class CartItemModel
    {
        public string ItemId { get; set; }

        public string CartId { get; set; }

        public int Quantity { get; set; }

        public DateTime DateCreated { get; set; }

        public ProductModel Product { get; set; }

    }
}
