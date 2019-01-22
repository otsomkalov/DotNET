using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DKR.Models
{
    public class Product : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        public ICollection<StoreProduct> StoreProducts { get; set; }
    }
}