using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.StoreProduct
{
    public class DetailsModel : PageModel
    {
        private readonly IStoreProductService _storeProductService;

        public DetailsModel(IStoreProductService storeProductService)
        {
            _storeProductService = storeProductService;
        }

        public Models.StoreProduct StoreProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            StoreProduct =
                await _storeProductService.GetByIdAsync(id.Value);

            if (StoreProduct == null) return NotFound();

            return Page();
        }
    }
}