using System.Threading.Tasks;
using Lab2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.ToDo
{
    public class EditModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public EditModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [BindProperty] public Models.ToDo ToDo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            ToDo = await _toDoService.GetByIdAsync(id.Value);

            if (ToDo == null) return NotFound();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            var toDo = await _toDoService.GetByIdAsync(ToDo.Id);

            if (toDo == null) return NotFound();

            await _toDoService.UpdateAsync(ToDo);

            return RedirectToPage("./Index");
        }
    }
}