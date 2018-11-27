using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessLogic.Models
{
    public class TransfertStockModel
    {
        public int FromStockId { get; set; }
        public int ToStockId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
