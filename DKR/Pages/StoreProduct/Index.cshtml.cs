using System.Collections.Generic;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.StoreProduct
{
    public class IndexModel : PageModel
    {
        private readonly IStoreProductService _storeProductService;

        public IndexModel(IStoreProductService storeProductService)
        {
            _storeProductService = storeProductService;
        }

        public IList<Models.StoreProduct> StoresProducts { get; set; }

        public async Task OnGetAsync()
        {
            StoresProducts = await _storeProductService.ListAsync();
        }
    }
}