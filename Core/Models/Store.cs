using System.Collections.Generic;

namespace Core.Models
{
    public class Store : BaseEntity
    {
        public int AddressId { get; set; }
        public int CompanyId { get; set; }

        public Address Address { get; set; }
        public Company Company { get; set; }

        public ICollection<StoreProduct> StoreProducts { get; set; }

        public override string ToString()
        {
            return $"{Company.Name}, {Address}";
        }
    }
}