using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Store
{
    public class IndexModel : PageModel
    {
        private readonly IStoreService _storeService;

        public IndexModel(IStoreService storeService)
        {
            _storeService = storeService;
        }

        public IList<Core.Models.Store> Stores { get; set; }

        public async Task OnGetAsync()
        {
            Stores = await _storeService.Get("Address", "Company");
        }
    }
}