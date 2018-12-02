using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.DataAcces.Entities
{
    [Table("ProductInventory")]
    public class ProductInventory
    {
        [Key]
        public int ProductId { get; set; }

        //public int ProductId { get; set; }

        //[ForeignKey("ProductId")]
        //public Product Product { get; set; }

        public int LocationId { get; set; }

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        public decimal Count { get; set; }
    }
}
