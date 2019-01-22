using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Store
{
    public class DetailsModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DetailsModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public Models.Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.GetByIdAsync(id.Value);

            if (Store == null) return NotFound();
            return Page();
        }
    }
}