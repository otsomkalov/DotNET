using System.Collections.Generic;
using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Company
{
    public class IndexModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public IndexModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IList<Models.Company> Companies { get; set; }

        public async Task OnGetAsync()
        {
            Companies = await _companyService.ListAsync();
        }
    }
}