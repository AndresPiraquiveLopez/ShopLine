namespace CartBusinessLogic.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        //public string Description { get; set; }

        public string ImagePath { get; set; }

        public double? UnitPrice { get; set; }

        public CategoryModel Category { get; set; }

        public int CategoryId { get; set; }

    }
}