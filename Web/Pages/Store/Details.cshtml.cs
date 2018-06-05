using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Store
{
    public class DetailsModel : PageModel
    {
        private readonly IStoreService _storeService;

        public DetailsModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public Core.Models.Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.Get(store => store.Id == id.Value, "Address", "Company");

            if (Store == null) return NotFound();
            return Page();
        }
    }
}