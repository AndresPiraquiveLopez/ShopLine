namespace InventoryBusinessLogic.Models
{
    public class ProductInventoryModel
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Location { get; set; }

        public int Qty { get; set; }        

        public bool Available { get; set; }

        public bool Reserved { get; set; }

        public bool OnOrder { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }
}
