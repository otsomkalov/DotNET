using System.Threading.Tasks;
using Lab2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.ToDo
{
    public class CreateModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public CreateModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [BindProperty] public Models.ToDo ToDo { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            await _toDoService.CreateAsync(ToDo);

            return RedirectToPage("./Index");
        }
    }
}