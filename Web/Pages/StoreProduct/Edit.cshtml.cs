using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.StoreProduct
{
    public class EditModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IStoreProductService _storeProductService;
        private readonly IStoreService _storeService;

        public EditModel(IStoreProductService storeProductService, IProductService productService,
            IStoreService storeService)
        {
            _storeProductService = storeProductService;
            _productService = productService;
            _storeService = storeService;
        }

        [BindProperty] public Core.Models.StoreProduct StoreProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            StoreProduct =
                await _storeProductService.Get(storeProduct => storeProduct.Id == id.Value, "Store", "Product");

            if (StoreProduct == null) return NotFound();

            ViewData["ProductId"] = new SelectList(await _productService.Get(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(await _storeService.Get(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeProductService.Update(StoreProduct);

            return RedirectToPage("./Index");
        }
    }
}