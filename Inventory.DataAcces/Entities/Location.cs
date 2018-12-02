using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DataAcces.Entities
{
    [Table("Location")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        public string Name { get; set; }
    }
}
