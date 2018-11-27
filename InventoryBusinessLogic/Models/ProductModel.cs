namespace InventoryBusinessLogic.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int ProductCategoryId { get; set; }

        public decimal Cost { get; set; }

        public decimal SellPrice { get; set; }
       
    }
}
