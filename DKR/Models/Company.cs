using System.ComponentModel.DataAnnotations;

namespace DKR.Models
{
    public class Company : BaseEntity
    {
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }
    }
}