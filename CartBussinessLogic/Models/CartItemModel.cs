using System;

namespace CartBusinessLogic.Models
{
    public class CartItemModel
    {
        public int ItemId { get; set; }

        public int Quantity { get; set; }

        public string CartId { get; set; }

        public int ProductId { get; set; }


        public DateTime DateCreated { get; set; }

        //public ProductModel Product { get; set; }

    }
}
