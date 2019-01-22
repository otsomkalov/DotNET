using System.Threading.Tasks;
using Lab2.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Pages.ToDo
{
    public class DetailsModel : PageModel
    {
        private readonly IToDoService _toDoService;

        public DetailsModel(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        public Models.ToDo ToDo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) return NotFound();

            ToDo = await _toDoService.GetByIdAsync(id.Value);

            if (ToDo == null) return NotFound();

            return Page();
        }
    }
}