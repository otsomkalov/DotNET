using System.Threading.Tasks;
using DKR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DKR.Pages.Company
{
    public class DetailsModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public DetailsModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public Models.Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Company = await _companyService.GetByIdAsync(id.Value);

            if (Company == null) return NotFound();
            return Page();
        }
    }
}