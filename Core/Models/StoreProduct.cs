namespace Core.Models
{
    public class StoreProduct : BaseEntity
    {
        public int Amount { get; set; }
        public int Price { get; set; }

        public int ProductId { get; set; }
        public int StoreId { get; set; }

        public Product Product { get; set; }
        public Store Store { get; set; }
    }
}