using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class Address : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Country { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Town { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Street { get; set; }

        [Required]
        [StringLength(5, MinimumLength = 1)]
        public string Building { get; set; }

        public virtual ICollection<Store> Stores { get; set; }

        public override string ToString()
        {
            return $"{Country}, {Town}, {Street}, {Building}";
        }
    }
}