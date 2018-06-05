using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Store
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

        [BindProperty] public Core.Models.Store Store { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Store = await _storeService.Get(store => store.Id == id, "Address", "Company");

            if (Store == null) return NotFound();
            ViewData["Addresses"] = new SelectList(await _addressService.Get(), "Id", "Building");
            ViewData["Companies"] = new SelectList(await _companyService.Get(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeService.Update(Store);

            return RedirectToPage("./Index");
        }
    }
}