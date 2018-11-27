using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DataAcces.Entities
{
    [Table("Stock")]
    public class Stock
    {
        [Key]
        public int StockId { get; set; }

        public string Name { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual  Product Product { get; set; }

        public int Qty { get; set; }
    }
}
