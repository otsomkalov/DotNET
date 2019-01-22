using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Address
{
    public class DeleteModel : PageModel
    {
        private readonly IAddressService _addressService;

        public DeleteModel(IAddressService addressService)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.GetByIdAsync(id.Value);

            if (Address != null) await _addressService.DeleteAsync(Address);

            return RedirectToPage("./Index");
        }
    }
}