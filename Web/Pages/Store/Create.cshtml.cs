using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.Pages.Store
{
    public class CreateModel : PageModel
    {
        private readonly IAddressService _addressService;
        private readonly ICompanyService _companyService;
        private readonly IStoreService _storeService;

        public CreateModel(IStoreService storeService, IAddressService addressService,
            ICompanyService companyService)
        {
            _storeService = storeService;
            _addressService = addressService;
            _companyService = companyService;
        }

        [BindProperty] public Core.Models.Store Store { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var addresses = (await _addressService.Get())
                .Select(address => new {address.Id, Address = address.ToString()});

            ViewData["AddressId"] = new SelectList(addresses, "Id", "Address");
            ViewData["CompanyId"] = new SelectList(await _companyService.Get(), "Id", "Name");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _storeService.Create(Store);

            return RedirectToPage("./Index");
        }
    }
}