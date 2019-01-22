using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DKR.Pages.StoreProduct
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

        [BindProperty] public Models.StoreProduct StoreProduct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            StoreProduct =
                await _storeProductService.GetByIdAsync(id.Value);

            if (StoreProduct == null) return NotFound();

            ViewData["ProductId"] = new SelectList(await _productService.ListAsync(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(await _storeService.ListAsync(), "Id", "Id");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeProductService.UpdateAsync(StoreProduct);

            return RedirectToPage("./Index");
        }
    }
}