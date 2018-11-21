namespace CatalogBusinessLogic.Models
{
    public class ProductInventory
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }        

        public int CategoryId { get; set; }

        public decimal Cost { get; set; }

        public decimal SellPrice { get; set; }

        public int Qty { get; set; }
    }
}
