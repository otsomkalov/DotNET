using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Store
{
    public class DeleteModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DeleteModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [BindProperty] public Models.Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.GetByIdAsync(id.Value);

            if (Store == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.GetByIdAsync(id.Value);

            if (Store != null) await _storeService.RemoveAsync(Store);

            return RedirectToPage("./Index");
        }
    }
}