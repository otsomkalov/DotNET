//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Lb3
{
    using System;
    using System.Collections.Generic;
    
    public partial class StoreProduct
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> StoreId { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
