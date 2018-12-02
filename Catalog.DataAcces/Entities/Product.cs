﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.DataAcces.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        //[ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
    }
}
