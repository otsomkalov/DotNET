using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DKR.Pages.Store
{
    public class EditModel : PageModel
    {
        private readonly IAddressService _addressService;
        private readonly ICompanyService _companyService;
        private readonly IStoreService _storeService;

        public EditModel(IStoreService storeService, IAddressService addressService,
            ICompanyService companyService)
        {
            _storeService = storeService;
            _addressService = addressService;
            _companyService = companyService;
        }

        [BindProperty] public Models.Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.GetByIdAsync(id.Value);

            if (Store == null) return NotFound();
            ViewData["Addresses"] = new SelectList(await _addressService.ListAsync(), "Id", "Building");
            ViewData["Companies"] = new SelectList(await _companyService.ListAsync(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeService.UpdateAsync(Store);

            return RedirectToPage("./Index");
        }
    }
}