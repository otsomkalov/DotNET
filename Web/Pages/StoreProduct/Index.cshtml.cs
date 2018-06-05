using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.StoreProduct
{
    public class IndexModel : PageModel
    {
        private readonly IStoreProductService _storeProductService;

        public IndexModel(IStoreProductService storeProductService)
        {
            _storeProductService = storeProductService;
        }

        public IList<Core.Models.StoreProduct> StoresProducts { get; set; }

        public async Task OnGetAsync()
        {
            StoresProducts = await _storeProductService.Get("Product", "Store");
        }
    }
}