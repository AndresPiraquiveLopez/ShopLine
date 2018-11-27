using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryBusinessLogic.Models
{
    public class StockModel
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public int Qty { get; set; }
    }
}
