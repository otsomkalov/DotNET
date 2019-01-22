using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Address
{
    public class CreateModel : PageModel
    {
        private readonly IAddressService _addressService;

        public CreateModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [BindProperty] public Models.Address Address { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _addressService.CreateAsync(Address);

            return RedirectToPage("./Index");
        }
    }
}