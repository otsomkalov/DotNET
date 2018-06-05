using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Address
{
    public class DeleteModel : PageModel
    {
        private readonly IAddressService _addressService;

        public DeleteModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [BindProperty] public Core.Models.Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.Get(address => address.Id == id.Value);

            if (Address == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.Get(address => address.Id == id);

            if (Address != null) await _addressService.Remove(Address);

            return RedirectToPage("./Index");
        }
    }
}