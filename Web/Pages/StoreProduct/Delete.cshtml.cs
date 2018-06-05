using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.StoreProduct
{
    public class DeleteModel : PageModel
    {
        private readonly IStoreProductService _storeProductService;

        public DeleteModel(IStoreProductService storeProductService)
        {
            _storeProductService = storeProductService;
        }

        [BindProperty] public Core.Models.StoreProduct StoreProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            StoreProduct =
                await _storeProductService.Get(storeProduct => storeProduct.Id == id.Value, "Store", "Product");

            if (StoreProduct == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            StoreProduct = await _storeProductService.Get(storeProduct => storeProduct.Id == id.Value);

            if (StoreProduct != null) await _storeProductService.Remove(StoreProduct);

            return RedirectToPage("./Index");
        }
    }
}