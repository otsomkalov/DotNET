using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Company
{
    public class DeleteModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public DeleteModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [BindProperty] public Core.Models.Company Company { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            Company = await _companyService.Get(company => company.Id == id.Value);

            if (Company == null) return NotFound();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null) return NotFound();

            Company = await _companyService.Get(company => company.Id == id.Value);

            if (Company != null) await _companyService.Remove(Company);

            return RedirectToPage("./Index");
        }
    }
}