using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Address
{
    public class EditModel : PageModel
    {
        private readonly IAddressService _addressService;

        public EditModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [BindProperty] public Models.Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.GetByIdAsync(id.Value);

            if (Address == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _addressService.UpdateAsync(Address);

            return RedirectToPage("./Index");
        }
    }
}