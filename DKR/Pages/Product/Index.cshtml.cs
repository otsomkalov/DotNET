using System.Collections.Generic;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public IList<Models.Product> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _productService.ListAsync();
        }
    }
}