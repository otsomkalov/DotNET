using System.Collections.Generic;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Store
{
    public class IndexModel : PageModel
    {
        private readonly IStoreService _storeService;

        public IndexModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IList<Models.Store> Stores { get; set; }

        public async Task OnGetAsync()
        {
            Stores = await _storeService.ListAsync();
        }
    }
}