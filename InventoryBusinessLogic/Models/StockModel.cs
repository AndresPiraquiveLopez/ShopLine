namespace InventoryBusinessLogic.Models
{
    public class StockModel
    {
        public int StockId { get; set; }

        public int ProductId { get; set; }

        public string Name { get; set; }

        public int Qty { get; set; }
    }
}
