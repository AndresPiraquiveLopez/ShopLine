using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogBusinessLogic.Models
{
    public class CategoryModel
    {

        public int Id { get; set; }

        public string CategoryName { get; set; }

        //public Foreign Key
        public int CatalogId { get; set; }

    }
}
