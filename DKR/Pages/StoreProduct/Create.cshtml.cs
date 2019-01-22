using System.Linq;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DKR.Pages.StoreProduct
{
    public class CreateModel : PageModel
    {
        private readonly IProductService _productService;
        private readonly IStoreProductService _storeProductService;
        private readonly IStoreService _storeService;

        public CreateModel(IStoreProductService storeProductService, IStoreService storeService,
            IProductService productService)
        {
            _storeProductService = storeProductService;
            _storeService = storeService;
            _productService = productService;
        }

        [BindProperty] public Models.StoreProduct StoreProduct { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var stores = (await _storeService.ListAsync())
                .Select(store => new {store.Id, Store = store.ToString()});

            ViewData["ProductId"] = new SelectList(await _productService.ListAsync(), "Id", "Name");
            ViewData["StoreId"] = new SelectList(stores, "Id", "Store");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeProductService.CreateAsync(StoreProduct);

            return RedirectToPage("./Index");
        }
    }
}