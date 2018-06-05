using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web.Pages.Company
{
    public class CreateModel : PageModel
    {
        private readonly ICompanyService _companyService;

        public CreateModel(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [BindProperty] public Core.Models.Company Company { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _companyService.Create(Company);

            return RedirectToPage("./Index");
        }
    }
}