using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Address
{
    public class CreateModel : PageModel
    {
        private readonly IAddressService _addressService;

        public CreateModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [BindProperty] public Core.Models.Address Address { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _addressService.Create(Address);

            return RedirectToPage("./Index");
        }
    }
}