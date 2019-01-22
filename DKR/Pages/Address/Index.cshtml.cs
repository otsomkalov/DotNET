using System.Collections.Generic;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Address
{
    public class IndexModel : PageModel
    {
        private readonly IAddressService _addressService;

        public IndexModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IList<Models.Address> Addresses { get; set; }

        public async Task OnGetAsync()
        {
            Addresses = await _addressService.ListAsync();
        }
    }
}