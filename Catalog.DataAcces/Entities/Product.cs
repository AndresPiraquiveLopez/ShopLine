﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.DataAcces.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public decimal Cost { get; set; }

        public decimal SellPrice { get; set; }

        public int Qty { get; set; }
    }
}