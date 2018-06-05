using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Address
{
    public class IndexModel : PageModel
    {
        private readonly IAddressService _addressService;

        public IndexModel(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IList<Core.Models.Address> Addresses { get; set; }

        public async Task OnGetAsync()
        {
            Addresses = await _addressService.Get();
        }
    }
}