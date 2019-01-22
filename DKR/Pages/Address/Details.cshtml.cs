using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Address
{
    public class DetailsModel : PageModel
    {
        private readonly IAddressService _addressService;

        public DetailsModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public Models.Address Address { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Address = await _addressService.GetByIdAsync(id.Value);

            if (Address == null) return NotFound();
            return Page();
        }
    }
}