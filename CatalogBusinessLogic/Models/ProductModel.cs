namespace CatalogBusinessLogic.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }        

        //public Foreign Key
        public int CategoryId { get; set; }

        public string ProductCode { get; set; }

        public decimal Cost { get; set; }

        public decimal SellPrice { get; set; }

    }
}
